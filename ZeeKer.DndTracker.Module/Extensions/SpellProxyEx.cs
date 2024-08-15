using DevExpress.ExpressApp;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.Extensions
{
    internal static class SpellProxyEx
    {


        public static Spell ToPersistent(this ISpell spellProxy, IObjectSpace objectSpace)
        {
            var spell = objectSpace.CreateObject<Spell>();
            spell.Name = spellProxy.Name;
            spell.SpellLevel = ToMagicSchoolLevel(spellProxy.SpellLevel);
            spell.MagicSchool = ConvertToMagicSchoolType(spellProxy.MagicSchool);
            spell.SpellCastingTime = spellProxy.SpellCastingTime;
            spell.Distance = spellProxy.Distance;
            spell.Components = spellProxy.Components;
            spell.Duration = spellProxy.Duration;
            spell.Descripton = spellProxy.Description;
            spell.DndsuLink = spellProxy.FullLink;
            spell.IsRitual = spellProxy.IsRitual;
            spell.NeedConcentration = spellProxy.NeedConcentration;
            spell.Source = ConvertToSourceType(spellProxy.Source);
            spell.LoadResult = LoadSpellResult.LoadSuccess;

            return spell;
        }

        public static void MapTo(this ISpell spellProxy, Spell spell)
        {
            spell.Name = spellProxy.Name;
            spell.SpellLevel = ToMagicSchoolLevel(spellProxy.SpellLevel);
            spell.MagicSchool = ConvertToMagicSchoolType(spellProxy.MagicSchool);
            spell.SpellCastingTime = spellProxy.SpellCastingTime;
            spell.Distance = spellProxy.Distance;
            spell.Components = spellProxy.Components;
            spell.Duration = spellProxy.Duration;
            spell.Descripton = spellProxy.Description;
            spell.DndsuLink = spellProxy.FullLink;
            spell.IsRitual = spellProxy.IsRitual;
            spell.NeedConcentration = spellProxy.NeedConcentration;
            spell.Source = ConvertToSourceType(spellProxy.Source);
            spell.LoadResult = LoadSpellResult.LoadSuccess;
        }

        private static SourceType ConvertToSourceType(string sourceName)
        {
            switch (sourceName)
            {
                case "«Player's handbook»":
                    return SourceType.PHB;
                case "«Xanathar's Guide to Everything»":
                    return SourceType.XGE;
                case "«Tasha's Cauldron of Everything»":
                    return SourceType.TCE;
                case "«Fizban's Treasury of Dragons»":
                    return SourceType.FTD;
                case "«The Book of Many Things»":
                    return SourceType.BMT;
                case "Homebrew":
                    return SourceType.HB;
                case "«Sword Coast Adventurer's Guide»":
                    return SourceType.PG;
                default:
                    return ContainsCheck(sourceName);
            }
        }

        private static SourceType ContainsCheck(string schoolName)
        {
            if (schoolName.Contains("Player's handbook", StringComparison.OrdinalIgnoreCase))
                return SourceType.PHB;
            else if (schoolName.Contains("Xanathar's Guide to Everything", StringComparison.OrdinalIgnoreCase))
                return SourceType.XGE;
            else if (schoolName.Contains("Tasha's Cauldron of Everything", StringComparison.OrdinalIgnoreCase))
                return SourceType.TCE;
            else if (schoolName.Contains("Fizban's Treasury of Dragons", StringComparison.OrdinalIgnoreCase))
                return SourceType.FTD;
            else if (schoolName.Contains("The Book of Many Things", StringComparison.OrdinalIgnoreCase))
                return SourceType.BMT;
            else if (schoolName.Contains("Homebrew", StringComparison.OrdinalIgnoreCase))   
                return SourceType.HB;      
            else if (schoolName.Contains("Sword Coast Adventurer's Guide", StringComparison.OrdinalIgnoreCase))
                return SourceType.PG;

            return SourceType.None;
        }

        private static MagicSchoolType ConvertToMagicSchoolType(string schoolName)
        {
            switch (schoolName)
            {
                case "ограждение":
                    return MagicSchoolType.Abjuration;
                case "вызов":
                    return MagicSchoolType.Conjuration;
                case "прорицание":
                    return MagicSchoolType.Divination;
                case "очарование":
                    return MagicSchoolType.Enchantment;
                case "воплощение":
                    return MagicSchoolType.Evocation;
                case "иллюзия":
                    return MagicSchoolType.Illusion;
                case "некромантия":
                    return MagicSchoolType.Necromancy;
                case "преобразование":
                    return MagicSchoolType.Transmutation;
                default:
                    return ContainsCheckSchool(schoolName);
            }
        }

        private static MagicSchoolType ContainsCheckSchool(string schoolName)
        {
            if (schoolName.Contains("ограждение", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Abjuration;
            else if (schoolName.Contains("вызов", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Conjuration;
            else if (schoolName.Contains("прорицание", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Divination;
            else if (schoolName.Contains("очарование", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Enchantment;
            else if (schoolName.Contains("воплощение", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Evocation;
            else if (schoolName.Contains("иллюзия", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Illusion;
            else if (schoolName.Contains("некромантия", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Necromancy;
            else if (schoolName.Contains("преобразование", StringComparison.OrdinalIgnoreCase))
                return MagicSchoolType.Transmutation;

            return MagicSchoolType.Unknown;
        }

        private static int ToMagicSchoolLevel(string magicSchoolLevel)
        {
            return magicSchoolLevel switch
            {
                "Заговор" => 0,
                "1 уровень" => 1,
                "2 уровень" => 2,
                "3 уровень" => 3,
                "4 уровень" => 4,
                "5 уровень" => 5,
                "6 уровень" => 6,
                "7 уровень" => 7,
                "8 уровень" => 8,
                "9 уровень" => 9,
            };
        }
    }
}
