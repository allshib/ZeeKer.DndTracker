using DevExpress.ExpressApp.DC;
using DevExpress.Utils.Localization.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum WeightWeaponType
    {
        [XafDisplayName("Обычный вес")]
        Default,
        [XafDisplayName("Легкое")]
        Light,
        [XafDisplayName("Тяжелое")]
        Heavy
    }
}
