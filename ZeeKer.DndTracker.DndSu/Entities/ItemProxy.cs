using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.ItemParser;
using ZeeKer.DndTracker.Contracts.Types;

namespace ZeeKer.DndTracker.DndSu.Entities
{
    public record ItemProxy : IItem
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; init; }
        /// <summary>
        /// Наименование (англ)
        /// </summary>
        public string? EnglishName { get; init; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// Редкость
        /// </summary>
        public RarityType Rarity { get; init; }


        /// <summary>
        /// Тип предмета
        /// </summary>
        public ItemType ItemType { get; init; }

        public string? SpecificWeaponType { get; init; }

        /// <summary>
        /// Источник
        /// </summary>
        public string? Source { get; init; }
        /// <summary>
        /// Полная ссылка
        /// </summary>
        public string? FullLink { get; init; }
        /// <summary>
        /// Нужна настройка
        /// </summary>
        public bool NeedSetting { get; init; }


        public WeaponType WeaponType { get; init; }


    }
}
