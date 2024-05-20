using DevExpress.ExpressApp.DC;
using DevExpress.Xpo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum RaceType
    {
        [XafDisplayName("Неизвестно")]
        Unknown = 0,
        [XafDisplayName("Ааракокра")]
        Aarakocra = 1,
        [XafDisplayName("Аасимар")]
        Aasimar = 2,
        [XafDisplayName("Автогном")]
        Autognome = 3,
        [XafDisplayName("Астральный эльф")]
        AstralElf = 4,
        [XafDisplayName("Багбир")]
        Bugbear = 5,
        [XafDisplayName("Ведалкен")]
        Vedalken = 6,
        [XafDisplayName("Вердан")]
        Verdan = 7,
        [XafDisplayName("Симик-гибрид")]
        SimicHybrid = 8,
        [XafDisplayName("Гит")]
        Gith = 9,
        [XafDisplayName("Гифф")]
        Giff = 10,
        [XafDisplayName("Гном")]
        Gnome = 11,
        [XafDisplayName("Гоблин")]
        Goblin = 12,
        [XafDisplayName("Голиаф")]
        Goliath = 13,
        [XafDisplayName("Грюн")]
        Grung = 14,
        [XafDisplayName("Дварф")]
        Dwarf = 15,
        [XafDisplayName("Генази")]
        Genasi = 16,
        [XafDisplayName("Драконорожденный")]
        Dragonborn = 17,
        [XafDisplayName("Харенгон")]
        Harengon = 18,
        [XafDisplayName("Калаштар")]
        Kalashtar = 19,
        [XafDisplayName("Кендер")]
        Kender = 20,
        [XafDisplayName("Кенку")]
        Kenku = 21,
        [XafDisplayName("Кентавр")]
        Centaur = 22,
        [XafDisplayName("Кобольд")]
        Kobold = 23,
        [XafDisplayName("Варфорджд")]
        Warforged = 24,
        [XafDisplayName("Леонин")]
        Leonin = 25,
        [XafDisplayName("Локатан")]
        Locathan = 26,
        [XafDisplayName("Локсодон")]
        Loxondon = 27,
        [XafDisplayName("Ящеролюд")]
        Lizardfolk = 28,
        [XafDisplayName("Минотавр")]
        Minotaur = 29,
        [XafDisplayName("Орк")]
        Orc = 30,
        [XafDisplayName("Плазмоид")]
        Plazmoid = 31,
        [XafDisplayName("Полуорк")]
        HalfOrc = 32,
        [XafDisplayName("Полурослик")]
        Halfling = 33,
        [XafDisplayName("Полуэльф")]
        HalfElf = 34,
        [XafDisplayName("Сатир")]
        Satyr = 35,
        [XafDisplayName("Оулин")]
        Owlin = 36,
        [XafDisplayName("Табакси")]
        Tabaxi = 37,
        [XafDisplayName("Тифлинг")]
        Tiefling = 38,
        [XafDisplayName("Тортль")]
        Tortle = 39,
        [XafDisplayName("Три-Крин")]
        ThriKreen = 40,
        [XafDisplayName("Тритон")]
        Triton = 41,
        [XafDisplayName("Фирболг")]
        Firbolg = 42,
        [XafDisplayName("Фея")]
        Fairy = 43,
        [XafDisplayName("Хадози")]
        Hadozee = 44,
        [XafDisplayName("Хобгоблин")]
        Hobgoblin = 45,
        [XafDisplayName("Оборотень")]
        Changeling = 46,
        [XafDisplayName("Человек")]
        Human = 47,
        [XafDisplayName("Шифт")]
        Shifter = 48,
        [XafDisplayName("Эльф")]
        Elf = 49,
        [XafDisplayName("Юань-ти чистокровный")]
        YuantiPureblood = 50
    }
}
