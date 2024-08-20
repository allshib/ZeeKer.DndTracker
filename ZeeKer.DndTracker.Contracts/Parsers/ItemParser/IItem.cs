using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Types;

namespace ZeeKer.DndTracker.Contracts.Parsers.ItemParser;

public interface IItem
{
    string? Name { get; }
    string? EnglishName { get; }
    string? Description { get; }

    string? Rarity { get; }


    ItemType ItemType { get; }
    
    
    string? Source { get; }
    string? FullLink { get; }

    bool NeedSetting { get; }
    string? SpecificWeaponType { get; }
}

