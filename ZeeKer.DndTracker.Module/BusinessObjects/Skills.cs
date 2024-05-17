using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    

    [XafDisplayName("Навыки")]
    public class Skills : BaseObject
    {
        public Skills() : base()
        {
            SkillDetails = new ObservableCollection<SkillDetail>();
        }

        [Browsable(false)]
        public virtual Guid? StatsId {  get; set; }
        [XafDisplayName("Характеристики")]
        public virtual CharacterStats Stats { get; set; }

        public virtual ObservableCollection<SkillDetail> SkillDetails { get; set; }

        [NotMapped]
        [XafDisplayName("Акробатика")]
        public virtual SkillDetail Acrobatics => GetSkillByType(SkillType.Acrobatics);

        [NotMapped]
        [XafDisplayName("Уход за животными")]
        public virtual SkillDetail AnimalHandling => GetSkillByType(SkillType.AnimalHandling);

        [NotMapped]
        [XafDisplayName("Магия")]
        public virtual SkillDetail Arcana => GetSkillByType(SkillType.Arcana);

        [NotMapped]
        [XafDisplayName("Атлетика")]
        public virtual SkillDetail Athletics => GetSkillByType(SkillType.Athletics);

        [NotMapped]
        [XafDisplayName("Обман")]
        public virtual SkillDetail Deception => GetSkillByType(SkillType.Deception);

        [NotMapped]
        [XafDisplayName("История")]
        public virtual SkillDetail History => GetSkillByType(SkillType.History);

        [NotMapped]
        [XafDisplayName("Проницательность")]
        public virtual SkillDetail Insight => GetSkillByType(SkillType.Insight);

        [NotMapped]
        [XafDisplayName("Запугивание")]
        public virtual SkillDetail Intimidation => GetSkillByType(SkillType.Intimidation);

        [NotMapped]
        [XafDisplayName("Расследование")]
        public virtual SkillDetail Investigation => GetSkillByType(SkillType.Investigation);

        [NotMapped]
        [XafDisplayName("Медицина")]
        public virtual SkillDetail Medicine => GetSkillByType(SkillType.Medicine);

        [NotMapped]
        [XafDisplayName("Природа")]
        public virtual SkillDetail Nature => GetSkillByType(SkillType.Nature);

        [NotMapped]
        [XafDisplayName("Восприятие")]
        public virtual SkillDetail Perception => GetSkillByType(SkillType.Perception);

        [NotMapped]
        [XafDisplayName("Выступление")]
        public virtual SkillDetail Performance => GetSkillByType(SkillType.Performance);

        [NotMapped]
        [XafDisplayName("Убеждение")]
        public virtual SkillDetail Persuasion => GetSkillByType(SkillType.Persuasion);

        [NotMapped]
        [XafDisplayName("Религия")]
        public virtual SkillDetail Religion => GetSkillByType(SkillType.Religion);

        [NotMapped]
        [XafDisplayName("Ловкость рук")]
        public virtual SkillDetail SleightOfHand => GetSkillByType(SkillType.SleightOfHand);

        [NotMapped]
        [XafDisplayName("Скрытность")]
        public virtual SkillDetail Stealth => GetSkillByType(SkillType.Stealth);

        [NotMapped]
        [XafDisplayName("Выживание")]
        public virtual SkillDetail Survival => GetSkillByType(SkillType.Survival);

        public override void OnCreated()
        {
            base.OnCreated();

            CreateSkill(SkillDependencyType.Dexterity, SkillType.Acrobatics);
            CreateSkill(SkillDependencyType.Wisdom, SkillType.AnimalHandling);
            CreateSkill(SkillDependencyType.Intelligence, SkillType.Arcana);
            CreateSkill(SkillDependencyType.Strength, SkillType.Athletics);
            CreateSkill(SkillDependencyType.Charisma, SkillType.Deception);
            CreateSkill(SkillDependencyType.Intelligence, SkillType.History);
            CreateSkill(SkillDependencyType.Wisdom, SkillType.Insight);
            CreateSkill(SkillDependencyType.Charisma, SkillType.Intimidation);
            CreateSkill(SkillDependencyType.Intelligence, SkillType.Investigation);
            CreateSkill(SkillDependencyType.Wisdom, SkillType.Medicine);
            CreateSkill(SkillDependencyType.Intelligence, SkillType.Nature);
            CreateSkill(SkillDependencyType.Wisdom, SkillType.Perception);
            CreateSkill(SkillDependencyType.Charisma, SkillType.Performance);
            CreateSkill(SkillDependencyType.Charisma, SkillType.Persuasion);
            CreateSkill(SkillDependencyType.Intelligence, SkillType.Religion);
            CreateSkill(SkillDependencyType.Dexterity, SkillType.SleightOfHand);
            CreateSkill(SkillDependencyType.Dexterity, SkillType.Stealth);
            CreateSkill(SkillDependencyType.Wisdom, SkillType.Survival);
        }

        private void CreateSkill(SkillDependencyType dependency, SkillType type)
        {
            var skill = ObjectSpace.CreateObject<SkillDetail>();
            skill.Dependency = dependency;
            skill.SkillType = type;
            skill.SkillsId = ID;
        }

        private SkillDetail GetSkillByType(SkillType skillType)
        {
            return SkillDetails?.FirstOrDefault(s => s.SkillType == skillType);
        }

    }


    
}