using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.ItemParser;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.DndSu.Entities;

namespace ZeeKer.DndTracker.DndSu.Parsers
{
    public class DndsuItemParser : DndsuParser, IItemParser
    {

        private readonly List<IItem> cachedItems = new();
        private readonly List<IItemLink> cachedItemLinks = new();


        public DndsuItemParser() : base()
        {
        }


        public Task<IItem?> FindItem(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IItem?> FindItem(ISpellLink spellLink)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<IItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IItem>> GetCachedItems()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IItemLink?>> GetItemLinks(string? html = null)
        {
            if (cachedItemLinks.Count > 0)
                return cachedItemLinks;

            //html = html ?? await client.GetAsync($"{baseUrl}/items/").Result.Content.ReadAsStringAsync();
            html = html?? File.ReadLines("items.txt").First();

            var document = await context.OpenAsync(req => req.Content(html));
            var pageTitle = document.QuerySelectorAll(".list-item__spell");

            foreach (var item in pageTitle)
            {
                var name = item.QuerySelector(".cards_list__item-name")?.TextContent;
                var spellLink = html ?? item.QuerySelector("a.cards_list__item-wrapper")?
                    .GetAttribute("href");

                if (name is not null && spellLink is not null)
                    cachedItemLinks.Add(new SimpleItemCard(name, $"{baseUrl}{spellLink}"));
            }
            return cachedItemLinks;
;
        }
    }
}
