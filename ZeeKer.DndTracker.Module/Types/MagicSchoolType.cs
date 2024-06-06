using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{

    public enum MagicSchoolType
    {
        [XafDisplayName("Не выбрано")]
        Unknown,
        [XafDisplayName("Ограждение")]
        Abjuration,

        [XafDisplayName("Вызов")]
        Conjuration,

        [XafDisplayName("Прорицание")]
        Divination,

        [XafDisplayName("Очарование")]
        Enchantment,

        [XafDisplayName("Воплощение")]
        Evocation,

        [XafDisplayName("Иллюзия")]
        Illusion,

        [XafDisplayName("Некромантия")]
        Necromancy,

        [XafDisplayName("Преобразование")]
        Transmutation
    }
    
}
