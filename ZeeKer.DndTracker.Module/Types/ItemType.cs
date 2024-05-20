using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.DC;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum ItemType
    {
        Unknown = 0,
        [XafDisplayName("Броня")]
        Armor = 1,
        [XafDisplayName("Оружие")]
        Weapon = 2,
        [XafDisplayName("Щит")]
        ShieldItem = 4,
    }
}
