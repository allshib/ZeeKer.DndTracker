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
using ZeeKer.DndTracker.Module.Extensions;

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

        

        [XafDisplayName("Сила")]
        public virtual int Strength { get; set; }

        [XafDisplayName("Сила Бонус")]
        public virtual int StrengthBonus => Strength.CalcStatsBonus();

        [XafDisplayName("Телосложение")]
        public virtual int Constitution { get; set; }

        [XafDisplayName("Телосложение Бонус")]
        public virtual int ConstitutionBonus => Constitution.CalcStatsBonus();
        [XafDisplayName("Интеллект")]
        public virtual int Intelegence { get; set; }
        [XafDisplayName("Интеллект Бонус")]
        public virtual int IntelegenceBonus => Intelegence.CalcStatsBonus();

        [XafDisplayName("Харизма")]
        public virtual int Charisma { get; set; }

        [XafDisplayName("Харизма Бонус")]
        public virtual int CharismaBonus => Charisma.CalcStatsBonus();

        [XafDisplayName("Ловкость")]
        public virtual int Dexterity { get; set; }

        [XafDisplayName("Ловкость Бонус")]
        public virtual int DexterityBonus => Dexterity.CalcStatsBonus();

        [XafDisplayName("Мудрость")]
        public virtual int Wisdom { get; set; }

        [XafDisplayName("Мудрость Бонус")]
        public virtual int WisdomBonus =>  Wisdom.CalcStatsBonus();

        [Browsable(false)]
        public virtual Guid? CharacterId { get; set; }

        [ForeignKey(nameof(CharacterId)), XafDisplayName("Персонаж")]
        public virtual Character? Character { get; set; }


        [XafDisplayName("Бонус мастерства")]
        public virtual int Profiency => CalculateProfiency();

        private int CalculateProfiency()
        {
            if (CharacterId is null || Character.Level < 5) return 2;

            if (Character.Level < 9) return 3;
            if (Character.Level < 13) return 4;
            if (Character.Level < 17) return 5;
            return 6;

        }
        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}