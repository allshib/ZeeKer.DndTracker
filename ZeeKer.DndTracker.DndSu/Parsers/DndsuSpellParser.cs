using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Io;
using ZeeKer.DndTracker.DndSu.Entities;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;

namespace ZeeKer.DndTracker.DndSu.Parsers
{
    public class DndsuSpellParser : DndsuParser, ISpellParser
    {
        private readonly List<ISpell> cachedSpells = new();
        private readonly List<ISpellLink> cachedSpellLinks = new();

        public DndsuSpellParser() : base()
        {
            
        }

        public async Task<ISpell?> FindSpell(string name)
        {
            if(cachedSpells.Count == 0)
                await GetSpellLinks();
            
            var card = cachedSpellLinks.FirstOrDefault(x => x.Name == name);
            
            if (card is null)
                return null;

            return await GetSpellCard(card.FullLink);
        }

        public async Task<ISpell?> FindSpell(ISpellLink spellLink)
        {
            return await GetSpellCard(spellLink.FullLink);
        }




        public async IAsyncEnumerable<ISpell> GetAllSpells()
        {
            cachedSpells.Clear();
            var spellLinks = await GetSpellLinks();

            foreach (var card in spellLinks)
            {
                var spell = await GetSpellCard(card.FullLink) ?? await GetSpellCard(card.FullLink);

                if (spell?.Name is not null)
                {
                    cachedSpells.Add(spell);
                    yield return spell;
                }


                Thread.Sleep(sleepTime);
            }

        }

        public async Task<IEnumerable<ISpell>> GetCachedSpells()
        {
            if (cachedSpells.Count == 0)
                await GetSpellLinks();

            return cachedSpells;
        }

        public async Task<IEnumerable<ISpellLink?>> GetSpellLinks(string? html = null)
        {
            if (cachedSpellLinks.Count > 0)
                return cachedSpellLinks;

            string spellsHtml = File.ReadLines("spells.txt").First();

            var document = await context.OpenAsync(req => req.Content(spellsHtml));
            var pageTitle = document.QuerySelectorAll(".cards_list__item");

            foreach (var item in pageTitle)
            {
                var name = item.QuerySelector(".cards_list__item-name")?.TextContent;
                var spellLink = html?? item.QuerySelector("a.cards_list__item-wrapper")?
                    .GetAttribute("href");

                if (name is not null && spellLink is not null)
                    cachedSpellLinks.Add(new SimpleSpellCard(name, $"{baseUrl}{spellLink}"));
            }
            return cachedSpellLinks;
        }
        private async Task<SpellProxy?> GetSpellCard(string spellLink)
        {
            HttpResponseMessage response = await client.GetAsync(spellLink);

            string htmlContent = await response.Content.ReadAsStringAsync();
            IDocument document = await context.OpenAsync(req => req.Content(htmlContent));
            IElement spellCard = document!.QuerySelector(".card-wrapper")!;

            return GetSpellFromHTMLWrapper(spellCard, spellLink);

        }
        private string GetSourceText(IElement document)
        {
            // Извлекаем все источники, которые находятся в <span> внутри <li> с текстом "Источник" или "Источники"
            var sourceElement = document.QuerySelector("ul.params li:contains('Источник'), ul.params li:contains('Источники') span");

            if (sourceElement is null)
                return string.Empty;

            var sources = sourceElement.TextContent.Trim();

            if (sources.Contains("Источники"))
                sources = sources.Replace("Источники: ", "");
            else if (sources.Contains("Источник"))
                sources = sources.Replace("Источник: ", "");
            return sources;
        }
        private SpellProxy? GetSpellFromHTMLWrapper(IElement document, string spellLink)
        {
            var name = document.QuerySelector("h2.card-title span")?.TextContent.Split('[')[0].Trim();
            
            if (name is null)
                return null;

            var englishName = document.QuerySelector("h2.card-title span")?.TextContent.Split('[')[1].Replace("]", "").Trim();
            var levelAndSchool = document.QuerySelector("ul.params li.size-type-alignment")?.TextContent.Trim();
            var level = levelAndSchool?.Split(',')[0].Trim();
            var school = levelAndSchool?.Split(',')[1].Trim();
            var isRitual = school?.Contains("ритуал") ?? false;
            var castingTime = document.QuerySelector("ul.params li:nth-child(2)")?.TextContent.Replace("Время накладывания:", "").Trim();
            var range = document.QuerySelector("ul.params li:nth-child(3)")?.TextContent.Replace("Дистанция:", "").Trim();
            var components = document.QuerySelector("ul.params li:nth-child(4)")?.TextContent.Replace("Компоненты:", "").Trim();
            var duration = document.QuerySelector("ul.params li:nth-child(5)")?.TextContent.Replace("Длительность:", "").Trim();
            var needConcentration = duration?.Contains("Концентрация") ?? false;
            var clasesses = document.QuerySelector("ul.params li:nth-child(6)")?.TextContent.Replace("Классы:", "").Trim();
            var source = GetSourceText(document);
            var description = document.QuerySelector("div[itemprop='description']")?.TextContent.Trim();

            return new SpellProxy(
                name, englishName, level, school, castingTime, range, components,
                duration, needConcentration, isRitual, clasesses, source, description, spellLink);
        }

        
    }
}
