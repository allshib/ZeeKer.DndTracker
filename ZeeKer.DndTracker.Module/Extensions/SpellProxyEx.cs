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
            spell.MagicSchool = ToMagicSchoolType(spellProxy.MagicSchool);
            spell.SpellCastingTime = spellProxy.SpellCastingTime;
            spell.Distance = spellProxy.Distance;
            spell.Components = spellProxy.Components;
            spell.Duration = spellProxy.Duration;
            spell.Descripton = spellProxy.Description;
            spell.DndsuLink = spellProxy.FullLink;
            spell.IsRitual = spellProxy.IsRitual;
            spell.NeedConcentration = spellProxy.NeedConcentration;
            //spell.Source = spellProxy.Source;
            return spell;
        }


        private static MagicSchoolType ToMagicSchoolType(string magicSchool)
        {
            return magicSchool switch
            {
                "Abjuration" => MagicSchoolType.Abjuration,
                "Conjuration" => MagicSchoolType.Conjuration,
                "Divination" => MagicSchoolType.Divination,
                "Enchantment" => MagicSchoolType.Enchantment,
                "Evocation" => MagicSchoolType.Evocation,
                "Illusion" => MagicSchoolType.Illusion,
                "Necromancy" => MagicSchoolType.Necromancy
            };
        }

        private static int ToMagicSchoolLevel(string magicSchoolLevel)
        {
            return magicSchoolLevel switch
            {
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
