using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum HandWeaponType
    {
        [XafDisplayName("По умолчанию")]
        Default,
        [XafDisplayName("Двуручное")]
        TwoHanded,
        [XafDisplayName("Универсальное")]
        Universal
    }
}
