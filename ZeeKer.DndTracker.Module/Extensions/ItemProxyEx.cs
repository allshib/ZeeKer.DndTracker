using Castle.DynamicProxy;
using DevExpress.ExpressApp;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.ItemParser;
using ZeeKer.DndTracker.Contracts.Types;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.Extensions;

public static class ItemProxyEx
{


    public static Item ToPersistent(this IItem itemProxy, IObjectSpace objectSpace)
    {
        var item = CreateItem(objectSpace, itemProxy.ItemType);


        item.Name = itemProxy.Name;
        item.EnglishName = itemProxy.EnglishName;
        item.Description = itemProxy.Description;
        item.Rarity = ConvertRarityType(itemProxy.Rarity);
        item.Category = itemProxy.ItemType;
        item.Source = GetSource(itemProxy.Source);
        item.DndsuLink = itemProxy.FullLink;
        item.NeedSetting = itemProxy.NeedSetting;

        if(item is WeaponItem weapon)
            weapon.WeaponType = itemProxy.WeaponType;



        return item;
    }

    private static ItemRarityType ConvertRarityType(RarityType rarityType)
    {
        return rarityType switch
        {
            RarityType.Common => ItemRarityType.Common,
            RarityType.Uncommon => ItemRarityType.Uncommon,
            RarityType.Rare => ItemRarityType.Rare,
            RarityType.VeryRare => ItemRarityType.VeryRare,
            RarityType.Legendary => ItemRarityType.Legendary,
            RarityType.Artifact => ItemRarityType.Artifact,
            _ => ItemRarityType.Common
        };
    }

    private static Item CreateItem(IObjectSpace objectSpace, Contracts.Types.ItemType type)
    {
        switch(type)
        {
            case Contracts.Types.ItemType.Armor:
                return objectSpace.CreateObject<ArmorItem>();
            case Contracts.Types.ItemType.Weapon:
                return objectSpace.CreateObject<WeaponItem>();
            case Contracts.Types.ItemType.ShieldItem:
                return objectSpace.CreateObject<ShieldItem>();
            case Contracts.Types.ItemType.Staff:
                return objectSpace.CreateObject<WeaponItem>();
            case Contracts.Types.ItemType.Rod:
                return objectSpace.CreateObject<WeaponItem>();
            default:
                return objectSpace.CreateObject<SimpleItem>();
        }
    }

    private static SourceType GetSource(string source)
    {
        if (source.Contains("Player's handbook", StringComparison.OrdinalIgnoreCase))
            return SourceType.PHB;
        else if (source.Contains("Xanathar's Guide to Everything", StringComparison.OrdinalIgnoreCase))
            return SourceType.XGE;
        else if (source.Contains("Tasha's Cauldron of Everything", StringComparison.OrdinalIgnoreCase))
            return SourceType.TCE;
        else if (source.Contains("Fizban's Treasury of Dragons", StringComparison.OrdinalIgnoreCase))
            return SourceType.FTD;
        else if (source.Contains("The Book of Many Things", StringComparison.OrdinalIgnoreCase))
            return SourceType.BMT;
        else if (source.Contains("Homebrew", StringComparison.OrdinalIgnoreCase))
            return SourceType.HB;
        else if (source.Contains("Sword Coast Adventurer's Guide", StringComparison.OrdinalIgnoreCase))
            return SourceType.PG;
        else if (source.Contains("Dungeon master's guide", StringComparison.OrdinalIgnoreCase))
            return SourceType.PHB;

        return SourceType.None;
    }
}
