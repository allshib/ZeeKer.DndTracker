using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum SkillDependencyType
    {
        [XafDisplayName("Сила")]
        Strength,
        [XafDisplayName("Ловкость")]
        Dexterity,
        [XafDisplayName("Выносливость")]
        Constitution,
        [XafDisplayName("Интеллект")]
        Intelligence,
        [XafDisplayName("Мудрость")]
        Wisdom,
        [XafDisplayName("Харизма")]
        Charisma
    }
}
