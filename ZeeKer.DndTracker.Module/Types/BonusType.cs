using DevExpress.ExpressApp.DC;
using DevExpress.Xpo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum BonusType
    {
        [XafDisplayName("Неизвестно")]
        Unknown,
        [XafDisplayName("Бонус харакетристик")]
        Stat
    }
}
