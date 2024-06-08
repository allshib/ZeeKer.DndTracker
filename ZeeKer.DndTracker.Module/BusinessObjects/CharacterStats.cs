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
using DevExpress.XtraReports.Parameters;
using ZeeKer.DndTracker.Module.Extensions;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<CharacterStats> CharacterStatss { get; set; }" syntax.
    //[DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    [XafDisplayName("Характеристики")]
   
    public class CharacterStats : BaseObject
    {
        public CharacterStats()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        #region CalculationMainStatRules
        [XafDisplayName("Основная характеристика")]
        public virtual SkillDependencyType MainStat { get; set; }


        [XafDisplayName("Дополнительный бонус попадания")]
        public virtual int AdditionalAttackBonus { get; set; }

        [XafDisplayName("Бонус попадания от основной характеристики")]
        public virtual int MainAttackBonus => MainStat switch
        {
            SkillDependencyType.Strength => StrengthBonus + Profiency + AdditionalAttackBonus,
            SkillDependencyType.Dexterity => DexterityBonus + Profiency + AdditionalAttackBonus,
            SkillDependencyType.Charisma => CharismaBonus + Profiency + AdditionalAttackBonus,
            SkillDependencyType.Constitution => ConstitutionBonus + Profiency + AdditionalAttackBonus,
            SkillDependencyType.Wisdom => WisdomBonus + Profiency + AdditionalAttackBonus,
            SkillDependencyType.Intelligence => IntelegenceBonus + Profiency + AdditionalAttackBonus,
            _ => throw new NotImplementedException()
        };

        [XafDisplayName("Бонус попадания дальнобойним/фехтовальным оружием (от ловкости)")]
        public virtual int LongerRangeWeaponsBonus => DexterityBonus + Profiency + AdditionalAttackBonus;

        [XafDisplayName("Бонус попадания оружием бб (от силы)")]
        public virtual int MelleeBonus => DexterityBonus + Profiency + AdditionalAttackBonus;

        #endregion




        [XafDisplayName("Сила")]
        public virtual int Strength { get; set; }

        [XafDisplayName("Сила (calc)"), NotMapped]
        public virtual string StrengthCalc {
            get
            {
                return $"{Strength} ({(Strength >= 10 ? "+" : "")}{StrengthBonus})";
            }
            set
            {
                var val = value?.Length>2? value.Substring(0, 2): value;

                if (int.TryParse(val, out int outValue))
                    Strength = outValue;

            }
        }

        [XafDisplayName("Сила Бонус"), NotMapped]
        public virtual int StrengthBonus => Strength.CalcStatsBonus();


        [XafDisplayName("Телосложение")]
        public virtual int Constitution { get; set; }
        [XafDisplayName("Телосложение (calc)"), NotMapped]
        public virtual string ConstitutionCalc
        {
            get
            {
                return $"{Constitution} ({(Constitution >= 10 ? "+" : "")}{ConstitutionBonus})";
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Constitution = outValue;

            }
        }

        [XafDisplayName("Телосложение Бонус"), NotMapped]
        public virtual int ConstitutionBonus => Constitution.CalcStatsBonus();
        [XafDisplayName("Интеллект")]
        public virtual int Intelegence { get; set; }
        [XafDisplayName("Интеллект (calc)"), NotMapped]
        public virtual string IntelegenceCalc
        {
            get
            {
                return $"{Intelegence} ({(Intelegence >= 10 ? "+" : "")}{IntelegenceBonus})";
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Intelegence = outValue;

            }
        }
        [XafDisplayName("Интеллект Бонус"), NotMapped]
        public virtual int IntelegenceBonus => Intelegence.CalcStatsBonus();

        [XafDisplayName("Харизма")]
        public virtual int Charisma { get; set; }
        [XafDisplayName("Харизма (calc)"), NotMapped]
        public virtual string CharismaCalc
        {
            get
            {
                return $"{Charisma} ({(Charisma >= 10 ? "+" : "")}{CharismaBonus})";
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Charisma = outValue;

            }
        }

        [XafDisplayName("Харизма Бонус"), NotMapped]
        public virtual int CharismaBonus => Charisma.CalcStatsBonus();

        [XafDisplayName("Ловкость")]
        public virtual int Dexterity { get; set; }

        [XafDisplayName("Ловкость (calc)"), NotMapped]
        public virtual string DexterityCalc
        {
            get
            {
                return $"{Dexterity} ({(Dexterity >= 10 ? "+" : "")}{DexterityBonus})";
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Dexterity = outValue;

            }
        }

        [XafDisplayName("Ловкость Бонус"), NotMapped]
        public virtual int DexterityBonus => Dexterity.CalcStatsBonus();

        [XafDisplayName("Мудрость")]
        public virtual int Wisdom { get; set; }
        [XafDisplayName("Мудрость (calc)"), NotMapped]
        public virtual string WisdomCalc
        {
            get
            {
                return $"{Wisdom} ({(Wisdom >= 10 ? "+" : "")}{WisdomBonus})";
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Wisdom = outValue;

            }
        }

        [XafDisplayName("Мудрость Бонус"), NotMapped]
        public virtual int WisdomBonus =>  Wisdom.CalcStatsBonus();

        [Browsable(false)]
        public virtual Guid? CharacterId { get; set; }

        [XafDisplayName("Персонаж")]
        public virtual Character? Character { get; set; }


        [XafDisplayName("Бонус мастерства"), NotMapped]
        public virtual int Profiency => CalculateProfiency();

        [XafDisplayName("Инициатива"), NotMapped]
        public virtual int Initiative => DexterityBonus;

        //[XafDisplayName("Скорость")]
        //public virtual int Speed { get; set; }

        [Browsable(false)]
        public virtual Guid? SkillsId { get; set; }
        [XafDisplayName("Навыки")]
        public virtual Skills Skills { get; set; }

        private int CalculateProfiency()
        {
            if (CharacterId is null || Character.Level < 5) return 2;

            if (Character.Level < 9) return 3;
            if (Character.Level < 13) return 4;
            if (Character.Level < 17) return 5;
            return 6;

        }
        public override void OnCreated()
        {
            base.OnCreated();

            Skills = ObjectSpace.CreateObject<Skills>();
        }
    }
}