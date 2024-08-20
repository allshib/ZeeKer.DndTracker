using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Contracts.Types;

public enum ItemType
{
    Unknown = 0,
    Armor = 1,           // Доспех
    Weapon = 2,          // Оружие
    ShieldItem = 4,      // Щит (не указан на изображении)
    Wand = 6,            // Волшебная палочка
    Rod = 7,             // Жезл
    Potion = 8,          // Зелье
    Ring = 9,            // Кольцо
    Staff = 10,          // Посох
    Scroll = 11,         // Свиток
    WondrousItem = 12    // Чудесный предмет
}

