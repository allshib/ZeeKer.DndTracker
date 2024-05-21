using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum DamageType
    {
        [XafDisplayName("Колющий")]
        Piercing,
        [XafDisplayName("Рубящий")]
        Slashing,
        [XafDisplayName("Дробящий")]
        Bludgeoning,
        [XafDisplayName("Огненный")]
        Fire,
        [XafDisplayName("Ледяной")]
        Cold,
        [XafDisplayName("Электрический")]
        Lightning,
        [XafDisplayName("Кислотный")]
        Acid,
        [XafDisplayName("Ядовитый")]
        Poison,
        [XafDisplayName("Психический")]
        Psychic,
        [XafDisplayName("Силовой")]
        Force,
        [XafDisplayName("Некротический")]
        Necrotic,
        [XafDisplayName("Сияющий")]
        Radiant,
        [XafDisplayName("Громовой")]
        Thunder
    }
}
