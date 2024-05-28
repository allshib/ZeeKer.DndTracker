using DevExpress.DashboardCommon.Native;
using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum DiceHitType
    {
        [XafDisplayName("Не выбрано")]
        None = 0,
        [XafDisplayName("1к6")]
        D6 = 6,
        [XafDisplayName("1к8")]
        D8 = 8,
        [XafDisplayName("1к10")]
        D10 = 10,
        [XafDisplayName("1к12")]
        D12 = 12
    }
}
