using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum GroupProfiencyType
    {
        [XafDisplayName("Неизвестно")]
        None = 0,
        [XafDisplayName("Оружие")]
        Weapons = 1,
        [XafDisplayName("Броня")]
        Armors = 2,
        [XafDisplayName("Инструменты")]
        Tools = 3,
        [XafDisplayName("Языки")]
        Languages = 4
    }
}
