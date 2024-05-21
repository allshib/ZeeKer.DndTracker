using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum WeaponRangeType
    {
        [XafDisplayName("Ближний бой")]
        Melee,
        [XafDisplayName("Дальний бой")]
        Ranged,
        [XafDisplayName("Универсальное")]
        Universal,
    }
}
