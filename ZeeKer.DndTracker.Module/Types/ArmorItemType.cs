using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum ArmorType
    {
        [XafDisplayName("Не задано")]
        None,
        [XafDisplayName("Лёгкая")]
        Light,
        [XafDisplayName("Средняя")]
        Medium,
        [XafDisplayName("Тяжёлая")]
        Heavy
    }
}
