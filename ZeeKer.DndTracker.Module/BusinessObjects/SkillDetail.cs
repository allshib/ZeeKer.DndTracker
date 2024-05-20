using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.Types;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ZeeKer.DndTracker.Module.UseCases.ExecuteMultipleTransactionUseCase;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Навык")]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public class SkillDetail : BaseObject
    {
        public SkillDetail() : base() { }
        [XafDisplayName("Навык (Текст)"), NotMapped]
        public virtual string DefaultProperty => $"{CaptionHelper.GetDisplayText(SkillType)} ({(Value > 0 ? "+" : "")}{Value})";

        [XafDisplayName("Значение"), NotMapped]
        public virtual int Value => GetBonus(Skills?.Stats, Dependency, HasSkill);
        [XafDisplayName("Владение")]
        public virtual bool HasSkill { get; set; }
        [XafDisplayName("От чего зависит")]
        public virtual SkillDependencyType Dependency { get; set; }
        [XafDisplayName("Навык")]
        public virtual SkillType SkillType { get; set; }


        [ForeignKey(nameof(SkillsId))]
        [XafDisplayName("Навыки")]
        public virtual Skills Skills { get; set; }
        [Browsable(false)]
        public virtual Guid? SkillsId { get; set; }

        private int GetBonus(CharacterStats stats, SkillDependencyType dependency, bool hasSkill)
        {
            if(stats is null)
                return 0;

            switch (dependency)
            {
                case SkillDependencyType.Strength: return stats.StrengthBonus + (hasSkill? stats.Profiency : 0);
                case SkillDependencyType.Dexterity: return stats.DexterityBonus + (hasSkill ? stats.Profiency : 0);
                case SkillDependencyType.Constitution: return stats.ConstitutionBonus + (hasSkill ? stats.Profiency : 0);
                case SkillDependencyType.Intelligence: return stats.IntelegenceBonus + (hasSkill ? stats.Profiency : 0);
                case SkillDependencyType.Wisdom: return stats.WisdomBonus + (hasSkill ? stats.Profiency : 0);
                case SkillDependencyType.Charisma: return stats.CharismaBonus + (hasSkill ? stats.Profiency : 0);
                default: throw new NotImplementedException();
            }
        }


        [Action(Caption = "Овладеть", AutoCommit = true, SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
        public void SetSkillOwn()
        {
            HasSkill = !HasSkill;
        }
    }
}
