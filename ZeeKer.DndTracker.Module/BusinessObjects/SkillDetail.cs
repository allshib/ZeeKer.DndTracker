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
using Riok.Mapperly.Abstractions;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Навык")]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public class SkillDetail : BaseObject
    {
        public SkillDetail() : base() { }
        [XafDisplayName("Навык (Текст)"), NotMapped, MapperIgnore]
        public virtual string DefaultProperty => $"{CaptionHelper.GetDisplayText(SkillType)} ({(Value > 0 ? "+" : "")}{Value})";

        [XafDisplayName("Значение"), NotMapped, MapperIgnore]
        public virtual int Value => GetBonus();
        [XafDisplayName("Владение")]
        public virtual bool HasSkill { get; set; }

        [XafDisplayName("Компетентность")]
        public virtual bool HasCompetence { get; set; }


        [XafDisplayName("От")]
        public virtual SkillDependencyType Dependency { get; set; }
        [XafDisplayName("Навык")]
        public virtual SkillType SkillType { get; set; }


        [ForeignKey(nameof(SkillsId))]
        [XafDisplayName("Навыки"), MapperIgnore]
        public virtual Skills Skills { get; set; }
        [Browsable(false), MapperIgnore]
        public virtual Guid? SkillsId { get; set; }

        private int GetBonus()
        {
            if(Skills?.Stats is null)
                return 0;


            switch (Dependency)
            {
                case SkillDependencyType.Strength: return Skills.Stats.StrengthBonus + CalculateProfiencyBonus();
                case SkillDependencyType.Dexterity: return Skills.Stats.DexterityBonus + CalculateProfiencyBonus();
                case SkillDependencyType.Constitution: return Skills.Stats.ConstitutionBonus + CalculateProfiencyBonus();
                case SkillDependencyType.Intelligence: return Skills.Stats.IntelegenceBonus + CalculateProfiencyBonus();
                case SkillDependencyType.Wisdom: return Skills.Stats.WisdomBonus + CalculateProfiencyBonus();
                case SkillDependencyType.Charisma: return Skills.Stats.CharismaBonus + CalculateProfiencyBonus();
                default: throw new NotImplementedException();
            }
        }

        private int CalculateProfiencyBonus()
            => HasCompetence
            ? Skills.Stats.Profiency * 2 
            : HasSkill ? Skills.Stats.Profiency : GetHandymanBonus();

        private int GetHandymanBonus()
            => Skills.Stats.IsHandyman ? Skills.Stats.Profiency / 2 : 0;


        [Action(Caption = "Овладеть", AutoCommit = true, SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
        public void SetSkillOwn()
        {
            if(HasSkill && HasCompetence)
            {                 
                HasSkill = false;
                HasCompetence = false;
            }
            else if(HasSkill)
                HasCompetence = true;
            else
                HasSkill = true;
        }

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);


            switch (e.PropertyName)
            {
                   case nameof(HasSkill) when HasSkill == false && HasCompetence == true:
                        HasCompetence = false;
                    break;
            }
        }
    }
}
