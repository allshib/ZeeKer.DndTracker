using DevExpress.ExpressApp.DC;

namespace ZeeKer.DndTracker.Module.Types;

public enum CharacterClassType
{
    Unknown = 0,
    [XafDisplayName("Бард")]
    Bard = 1,
    [XafDisplayName("Варвар")]
    Barbarian = 2,
    [XafDisplayName("Воин")]
    Fighter = 3,
    [XafDisplayName("Волшебник")]
    Wizard = 4,
    [XafDisplayName("Друид")]
    Druid = 5,
    [XafDisplayName("Жрец")]
    Cleric = 6,
    [XafDisplayName("Изобретатель")]
    Artificer = 7,
    [XafDisplayName("Колдун")]
    Warlock = 8,
    [XafDisplayName("Монах")]
    Monk = 9,
    [XafDisplayName("Паладин")]
    Paladin = 10,
    [XafDisplayName("Плут")]
    Rogue = 11,
    [XafDisplayName("Следопыт")]
    Ranger = 12,
    [XafDisplayName("Чародей")]
    Sorcerer = 13,
    [XafDisplayName("Мистик")]
    Mystic = 14,
    [XafDisplayName("Боец")]
    WarriorSidekick = 15,
    [XafDisplayName("Заклинатель")]
    SpellcasterSidekick = 16,
    [XafDisplayName("Эксперт")]
    ExpertSidekick = 17,


    Homebrew = 100,
    [XafDisplayName("Алхимик")]
    Alchemist = 101,
    [XafDisplayName("Альтернативный воин")]
    AlternateFighter = 102,
    [XafDisplayName("Альтернативный монах")]
    AlternateMonk = 103,
    [XafDisplayName("Военачальник")]
    Warlord = 104,
    [XafDisplayName("Егерь")]
    Jaeger = 105,
    [XafDisplayName("Звездочет")]
    Stargazer = 106,
    [XafDisplayName("Кровавый охотник")]
    BloodHunter = 107,
    [XafDisplayName("Магус")]
    Magus = 108,
    [XafDisplayName("Неупокоенная душа")]
    TheLingeringSoul = 109,
    [XafDisplayName("Савант")]
    Savant = 110,
    [XafDisplayName("Хранитель рун")]
    Runekeeper = 112,
    [XafDisplayName("Шаман")]
    Shaman = 113,

}