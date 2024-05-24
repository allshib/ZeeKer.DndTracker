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
        [XafDisplayName("Ткань")]
        Cloth = 1,
        [XafDisplayName("Лёгкая броня")]
        Light=2,
        [XafDisplayName("Средняя броня")]
        Medium=3,
        [XafDisplayName("Тяжёлая броня")]
        Heavy=4,
        
        
    }
}
