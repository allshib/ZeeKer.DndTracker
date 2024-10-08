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
using Riok.Mapperly.Abstractions;

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

        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        [XafDisplayName("Бонус попадания (добавить)")]
        public virtual int AdditionalAttackBonus { get; set; }

        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        [XafDisplayName("Бонус попадания (основная хар-ка)")]
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

        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        [XafDisplayName("Бонус попадания (ловкость)")]
        public virtual int LongerRangeWeaponsBonus => DexterityBonus + Profiency + AdditionalAttackBonus;

        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        [XafDisplayName("Бонус попадания (сила)")]
        public virtual int MelleeBonus => StrengthBonus + Profiency + AdditionalAttackBonus;

        #endregion


        [XafDisplayName("Мастер на все руки")]
        public virtual bool IsHandyman { get; set; }


        [XafDisplayName("Сила")]
        public virtual int Strength { get; set; }

        [XafDisplayName("Сила (calc)"), NotMapped, MapperIgnore]
        public virtual string StrengthCalc {
            get
            {
                return CalcStatInfo(Strength, StrengthBonus, ProficiencyType.StrengthSavingThrow);
            }
            set
            {
                var val = value?.Length>2? value.Substring(0, 2): value;

                if (int.TryParse(val, out int outValue))
                    Strength = outValue;

            }
        }

        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        [XafDisplayName("Сила Бонус"), NotMapped, MapperIgnore]
        public virtual int StrengthBonus => Strength.CalcStatsBonus();


        [XafDisplayName("Телосложение")]
        public virtual int Constitution { get; set; }
        [XafDisplayName("Телосложение (calc)"), NotMapped, MapperIgnore]
        public virtual string ConstitutionCalc
        {
            get
            {
                return CalcStatInfo(Constitution, ConstitutionBonus, ProficiencyType.ConstitutionSavingThrow);
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Constitution = outValue;

            }
        }

        [XafDisplayName("Телосложение Бонус"), NotMapped, MapperIgnore]
        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        public virtual int ConstitutionBonus => Constitution.CalcStatsBonus();
        [XafDisplayName("Интеллект")]
        public virtual int Intelegence { get; set; }
        [XafDisplayName("Интеллект (calc)"), NotMapped, MapperIgnore]
        public virtual string IntelegenceCalc
        {
            get
            {
                return CalcStatInfo(Intelegence, IntelegenceBonus, ProficiencyType.IntelligenceSavingThrow);
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Intelegence = outValue;

            }
        }
        [XafDisplayName("Интеллект Бонус"), NotMapped, MapperIgnore]
        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        public virtual int IntelegenceBonus => Intelegence.CalcStatsBonus();

        [XafDisplayName("Харизма")]
        public virtual int Charisma { get; set; }
        [XafDisplayName("Харизма (calc)"), NotMapped, MapperIgnore]
        public virtual string CharismaCalc
        {
            get
            {
                return CalcStatInfo(Charisma, CharismaBonus, ProficiencyType.CharismaSavingThrow);
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Charisma = outValue;

            }
        }

        [XafDisplayName("Харизма Бонус"), NotMapped, MapperIgnore]
        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        public virtual int CharismaBonus => Charisma.CalcStatsBonus();

        [XafDisplayName("Ловкость")]
        public virtual int Dexterity { get; set; }

        [XafDisplayName("Ловкость (calc)"), NotMapped, MapperIgnore]
        public virtual string DexterityCalc
        {
            get
            {
                return CalcStatInfo(Dexterity, DexterityBonus, ProficiencyType.DexteritySavingThrow);
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Dexterity = outValue;

            }
        }

        [XafDisplayName("Ловкость Бонус"), NotMapped, MapperIgnore]
        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        public virtual int DexterityBonus => Dexterity.CalcStatsBonus();

        [XafDisplayName("Мудрость")]
        public virtual int Wisdom { get; set; }
        [XafDisplayName("Мудрость (calc)"), NotMapped, MapperIgnore]
        public virtual string WisdomCalc
        {
            get
            {
                return CalcStatInfo(Wisdom, WisdomBonus, ProficiencyType.WisdomSavingThrow);
            }
            set
            {
                var val = value?.Length > 2 ? value.Substring(0, 2) : value;

                if (int.TryParse(val, out int outValue))
                    Wisdom = outValue;

            }
        }

        [XafDisplayName("Мудрость Бонус"), NotMapped, MapperIgnore]
        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        public virtual int WisdomBonus =>  Wisdom.CalcStatsBonus();

        [Browsable(false), MapperIgnore]
        public virtual Guid? CharacterId { get; set; }

        [XafDisplayName("Персонаж"), MapperIgnore]
        public virtual Character? Character { get; set; }


        [XafDisplayName("Бонус мастерства"), NotMapped, MapperIgnore]
        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        public virtual int Profiency => CalculateProfiency();

        [XafDisplayName("Инициатива"), NotMapped, MapperIgnore]
        [ModelDefault("DisplayFormat", "{0:+0;-0;0}")]
        public virtual int Initiative => DexterityBonus + GetHandymanBonus();

        //[XafDisplayName("Скорость")]
        //public virtual int Speed { get; set; }

        [Browsable(false), MapperIgnore]
        public virtual Guid? SkillsId { get; set; }
        [XafDisplayName("Навыки"), MapperIgnore]
        public virtual Skills Skills { get; set; }

        private int CalculateProfiency()
        {
            if (CharacterId is null || Character.Level < 5) return 2;

            if (Character.Level < 9) return 3;
            if (Character.Level < 13) return 4;
            if (Character.Level < 17) return 5;
            return 6;

        }

        private string CalcStatInfo(int stat, int bonus, ProficiencyType spasType )
        {
            var spas = Character?.Profiencies?.Any(x => x.Profiency.ProfiencyType == spasType) == true 
                ? bonus + Profiency
                : bonus + GetHandymanBonus();

            return $"{stat} ({(stat >= 10 ? "+" : "")}{bonus}, Спас: {(spas > 0 ? "+" : "")}{spas})";
        }

        private int GetHandymanBonus()
        {
               return IsHandyman ? Profiency / 2 : 0;
        }

        public override void OnCreated()
        {
            base.OnCreated();

            Skills = ObjectSpace.CreateObject<Skills>();
        }
    }
}