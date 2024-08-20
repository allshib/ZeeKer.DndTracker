using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Contracts.Types;

/// <summary>
/// Перечисление для стандартных видов оружия D&D.
/// </summary>
public enum WeaponType
{
    /// <summary>
    /// Неизвестное оружие или не указано.
    /// </summary>
    Unknown = 0,

    AnyWeapon,
    AnySword,
    AnyCrossbow,


    // Простое оружие ближнего боя
    /// <summary>
    /// Дубинка.
    /// </summary>
    Club,
    /// <summary>
    /// Кинжал.
    /// </summary>
    Dagger,
    /// <summary>
    /// Большая дубинка.
    /// </summary>
    Greatclub,
    /// <summary>
    /// Ручной топор.
    /// </summary>
    Handaxe,
    /// <summary>
    /// Метательное копье.
    /// </summary>
    Javelin,
    /// <summary>
    /// Легкий молот.
    /// </summary>
    LightHammer,
    /// <summary>
    /// Булава.
    /// </summary>
    Mace,
    /// <summary>
    /// Боевой посох.
    /// </summary>
    Quarterstaff,
    /// <summary>
    /// Серп.
    /// </summary>
    Sickle,
    /// <summary>
    /// Копье.
    /// </summary>
    Spear,

    // Простое оружие дальнего боя

    /// <summary>
    /// Легкий арбалет.
    /// </summary>
    CrossbowLight,
    /// <summary>
    /// Дротик.
    /// </summary>
    Dart,
    /// <summary>
    /// Короткий лук.
    /// </summary>
    Shortbow,
    /// <summary>
    /// Праща.
    /// </summary>
    Sling,

    // Военное оружие ближнего боя
    /// <summary>
    /// Боевый топор.
    /// </summary>
    Battleaxe,
    /// <summary>
    /// Цеп.
    /// </summary>
    Flail,
    /// <summary>
    /// Глефа.
    /// </summary>
    Glaive,
    /// <summary>
    /// Большой топор.
    /// </summary>
    Greataxe,
    /// <summary>
    /// Большой меч.
    /// </summary>
    Greatsword,
    /// <summary>
    /// Алебарда.
    /// </summary>
    Halberd,
    /// <summary>
    /// Копье для рыцарских турниров.
    /// </summary>
    Lance,
    /// <summary>
    /// Длинный меч.
    /// </summary>
    Longsword,
    /// <summary>
    /// Молот.
    /// </summary>
    Maul,
    /// <summary>
    /// Моргенштерн.
    /// </summary>
    Morningstar,
    /// <summary>
    /// Пика.
    /// </summary>
    Pike,
    /// <summary>
    /// Рапира.
    /// </summary>
    Rapier,
    /// <summary>
    /// Скимитар.
    /// </summary>
    Scimitar,
    /// <summary>
    /// Короткий меч.
    /// </summary>
    Shortsword,
    /// <summary>
    /// Трезубец.
    /// </summary>
    Trident,
    /// <summary>
    /// Боевое копье.
    /// </summary>
    WarPick,
    /// <summary>
    /// Боевый молот.
    /// </summary>
    Warhammer,
    /// <summary>
    /// Кнут.
    /// </summary>
    Whip,

    // Военное оружие дальнего боя

    /// <summary>
    /// Духовая трубка.
    /// </summary>
    Blowgun,
    /// <summary>
    /// Ручной арбалет.
    /// </summary>
    CrossbowHand,
    /// <summary>
    /// Тяжелый арбалет.
    /// </summary>
    CrossbowHeavy,
    /// <summary>
    /// Длинный лук.
    /// </summary>
    Longbow,
    /// <summary>
    /// Сеть.
    /// </summary>
    Net
}

