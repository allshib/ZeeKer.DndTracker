using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.ItemParser;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.Contracts.Types;
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


        public async Task<IItem?> FindItem(string name)
        {
            if (cachedItemLinks.Count == 0)
                await GetItemLinks();

            var card = cachedItemLinks.FirstOrDefault(x => x.Name == name);

            if (card is null)
                return null;

            return await GetItemCard(card.FullLink);
        }

        public Task<IItem?> FindItem(ISpellLink spellLink)
        {
            throw new NotImplementedException();
        }

        public async IAsyncEnumerable<IItem> GetAllItems()
        {
            cachedItems.Clear();
            var itemLinks = await GetItemLinks();

            foreach (var card in itemLinks)
            {
                var spell = await GetItemCard(card.FullLink) ?? await GetItemCard(card.FullLink);

                if (spell?.Name is not null)
                {
                    cachedItems.Add(spell);
                    yield return spell;
                }


                Thread.Sleep(sleepTime);
            }
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
            html = html ?? File.ReadLines("items.txt").First();

            var document = await context.OpenAsync(req => req.Content(html));
            var itemCards = document.QuerySelectorAll("a.list-item-wrapper");

            foreach (var card in itemCards)
            {
                var link = card?.GetAttribute("href");

                var name = card?.QuerySelector("div.list-item-title")?.TextContent.Trim();

                if (name is not null && link is not null)
                    cachedItemLinks.Add(new SimpleItemCard(name, $"{baseUrl}{link}"));
            }
            return cachedItemLinks;
            ;
        }


        private ItemProxy? ParseItemCard(IElement document, string itemLink)
        {
            if (document is null)
                return null;
            var nameElement = document.QuerySelector("h2.card-title span");
            var typeAndRarityElement = document.QuerySelector("ul.params li.size-type-alignment");
            var sourceElement = document.QuerySelector("ul.params li:contains('Источник') span");
            var descriptionElement = document.QuerySelector("div[itemprop='description']");


            var name = nameElement?.TextContent.Split('[')[0].Trim();
            var engName = nameElement?.TextContent.Split('[')[1].Replace("]", "").Trim();
            var rarity = ExtractRarity(typeAndRarityElement?.TextContent);
            var type = DetermineItemType(typeAndRarityElement?.TextContent);

            var price = document.QuerySelector("ul.params li.price")?.TextContent.Replace("Рекомендованная стоимость:", "").Trim();
            var source = sourceElement?.TextContent.Trim();
            var needNeedSetting = typeAndRarityElement?.TextContent.Contains("требуется настройка") ?? false;

            var description = descriptionElement?.TextContent.Trim();


            var weapon = type == ItemType.Weapon
                    ? ExtractSpecificWeaponType(typeAndRarityElement?.TextContent)
                    : "";
            var weaponType = GetWeaponType(weapon);

            return new ItemProxy {
                Name = name,
                Source = source,
                Description = description,
                FullLink = itemLink,
                NeedSetting = needNeedSetting,
                ItemType = type,
                EnglishName = engName,
                Rarity = rarity,
                SpecificWeaponType = type == ItemType.Weapon
                    ? ExtractSpecificWeaponType(typeAndRarityElement?.TextContent)
                    : "",
                WeaponType = weaponType
            };
        }
        private WeaponType GetWeaponType(string? specificWeaponType)
        {
            if (string.IsNullOrEmpty(specificWeaponType))
                return WeaponType.Unknown;

            // Приводим текст к нижнему регистру для облегчения сравнения
            var lowerCaseType = specificWeaponType.ToLower();

            return lowerCaseType switch
            {
                "дубинка" => WeaponType.Club,
                "кинжал" => WeaponType.Dagger,
                "большая дубинка" => WeaponType.Greatclub,
                "ручной топор" => WeaponType.Handaxe,
                "метательное копье" => WeaponType.Javelin,
                "легкий молот" => WeaponType.LightHammer,
                "булава" => WeaponType.Mace,
                "боевой посох" => WeaponType.Quarterstaff,
                "серп" => WeaponType.Sickle,
                "копье" => WeaponType.Spear,
                "легкий арбалет" => WeaponType.CrossbowLight,
                "дротик" => WeaponType.Dart,
                "короткий лук" => WeaponType.Shortbow,
                "праща" => WeaponType.Sling,
                "боевой топор" => WeaponType.Battleaxe,
                "цеп" => WeaponType.Flail,
                "глефа" => WeaponType.Glaive,
                "большой топор" => WeaponType.Greataxe,
                "большой меч" => WeaponType.Greatsword,
                "алебарда" => WeaponType.Halberd,
                "копье для рыцарских турниров" => WeaponType.Lance,
                "длинный меч" => WeaponType.Longsword,
                "молот" => WeaponType.Maul,
                "моргенштерн" => WeaponType.Morningstar,
                "пика" => WeaponType.Pike,
                "рапира" => WeaponType.Rapier,
                "скимитар" => WeaponType.Scimitar,
                "короткий меч" => WeaponType.Shortsword,
                "трезубец" => WeaponType.Trident,
                "боевое копье" => WeaponType.WarPick,
                "боевой молот" => WeaponType.Warhammer,
                "кнут" => WeaponType.Whip,
                "духовая трубка" => WeaponType.Blowgun,
                "ручной арбалет" => WeaponType.CrossbowHand,
                "тяжелый арбалет" => WeaponType.CrossbowHeavy,
                "длинный лук" => WeaponType.Longbow,
                "сеть" => WeaponType.Net,
                "любой меч" => WeaponType.AnySword,
                "любой арбалет" => WeaponType.AnyCrossbow,
                "любое" => WeaponType.AnyWeapon,
                _ => WeaponType.Unknown
            };
        }

        private string? ExtractSpecificWeaponType(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var match = Regex.Match(text, @"\((.*?)\)");
            return match.Success ? match.Groups[1].Value : null;
        }

        private string ExtractRarity(string? text)
        {
            if (string.IsNullOrEmpty(text)) return "Неизвестный";

            // Учитываем все возможные окончания и новые типы редкости
            if (Regex.IsMatch(text, @"\bредкость варьируется\b", RegexOptions.IgnoreCase))
                return "Редкость варьируется";
            if (Regex.IsMatch(text, @"\bочень\sредк(?:ий|ая|ое|ие|ого|ой|ому|ыми|ых)\b", RegexOptions.IgnoreCase))
                return "Очень редкий";
            if (Regex.IsMatch(text, @"\bредк(?:ий|ая|ое|ие|ого|ой|ому|ыми|ых)\b", RegexOptions.IgnoreCase))
                return "Редкий";
            if (Regex.IsMatch(text, @"\bнеобычн(?:ый|ая|ое|ие|ого|ой|ому|ыми|ых)\b", RegexOptions.IgnoreCase))
                return "Необычный";
            if (Regex.IsMatch(text, @"\bлегендарн(?:ый|ая|ое|ие|ого|ой|ому|ыми|ых)\b", RegexOptions.IgnoreCase))
                return "Легендарный";
            if (Regex.IsMatch(text, @"\bобычн(?:ый|ая|ое|ие|ого|ой|ому|ыми|ых)\b", RegexOptions.IgnoreCase))
                return "Обычный";
            if (Regex.IsMatch(text, @"\bартефакт\b", RegexOptions.IgnoreCase))
                return "Артефакт";
            if (Regex.IsMatch(text, @"\bне имеет редкости\b", RegexOptions.IgnoreCase))
                return "Не имеет редкости";
            

            return "Неизвестный";
        }
        ItemType DetermineItemType(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return ItemType.Unknown;

            if (text.Contains("Доспех"))
                return ItemType.Armor;
            if (text.Contains("Оружие"))
                return ItemType.Weapon;
            if (text.Contains("Волшебная палочка"))
                return ItemType.Wand;
            if (text.Contains("Жезл"))
                return ItemType.Rod;
            if (text.Contains("Зелье"))
                return ItemType.Potion;
            if (text.Contains("Кольцо"))
                return ItemType.Ring;
            if (text.Contains("Посох"))
                return ItemType.Staff;
            if (text.Contains("Свиток"))
                return ItemType.Scroll;
            if (text.Contains("Чудесный предмет"))
                return ItemType.WondrousItem;

            return ItemType.Unknown;
        }
        private async Task<ItemProxy?> GetItemCard(string link)
        {
            var response = await client.GetAsync(link);

            var htmlContent = await response.Content.ReadAsStringAsync();
            var document = await context.OpenAsync(req => req.Content(htmlContent));
            var htmlCard = document!.QuerySelector("div.cards-wrapper")!;

            return ParseItemCard(htmlCard, link);

        }
    }
}
