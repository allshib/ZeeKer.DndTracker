using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum ProficiencyType
    {
        // Armor Proficiencies
        [XafDisplayName("Владение легкой броней")]
        LightArmor,
        [XafDisplayName("Владение средней броней")]
        MediumArmor,
        [XafDisplayName("Владение тяжелой броней")]
        HeavyArmor,
        [XafDisplayName("Владение щитом")]
        Shield,

        // Weapon Proficiencies
        [XafDisplayName("Владение простым оружием")]
        SimpleWeapons,
        [XafDisplayName("Владение боевым оружием")]
        MartialWeapons,

        // Tool Proficiencies
        [XafDisplayName("Владение ремесленными инструментами")]
        ArtisansTools,
        [XafDisplayName("Владение игровыми наборами")]
        GamingSets,
        [XafDisplayName("Владение музыкальными инструментами")]
        MusicalInstruments,
        [XafDisplayName("Кастомный язык")]
        CustomLanguage,
        [XafDisplayName("Спасбросок Силы")]
        StrengthSavingThrow,

        [XafDisplayName("Спасбросок Ловкости")]
        DexteritySavingThrow,

        [XafDisplayName("Спасбросок Телосложения")]
        ConstitutionSavingThrow,

        [XafDisplayName("Спасбросок Интеллекта")]
        IntelligenceSavingThrow,

        [XafDisplayName("Спасбросок Мудрости")]
        WisdomSavingThrow,

        [XafDisplayName("Спасбросок Харизмы")]
        CharismaSavingThrow
    }
}
