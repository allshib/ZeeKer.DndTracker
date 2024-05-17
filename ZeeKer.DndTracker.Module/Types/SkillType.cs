using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum SkillType
    {
        [XafDisplayName("Акробатика")]
        Acrobatics,
        [XafDisplayName("Уход за животными")]
        AnimalHandling,
        [XafDisplayName("Магия")]
        Arcana,
        [XafDisplayName("Атлетика")]
        Athletics,
        [XafDisplayName("Обман")]
        Deception,
        [XafDisplayName("История")]
        History,
        [XafDisplayName("Проницательность")]
        Insight,
        [XafDisplayName("Запугивание")]
        Intimidation,
        [XafDisplayName("Расследование")]
        Investigation,
        [XafDisplayName("Медицина")]
        Medicine,
        [XafDisplayName("Природа")]
        Nature,
        [XafDisplayName("Восприятие")]
        Perception,
        [XafDisplayName("Выступление")]
        Performance,
        [XafDisplayName("Убеждение")]
        Persuasion,
        [XafDisplayName("Религия")]
        Religion,
        [XafDisplayName("Ловкость рук")]
        SleightOfHand,
        [XafDisplayName("Скрытность")]
        Stealth,
        [XafDisplayName("Выживание")]
        Survival
    }
}
