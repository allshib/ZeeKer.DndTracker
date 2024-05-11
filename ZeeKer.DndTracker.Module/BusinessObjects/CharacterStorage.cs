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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Хранилище")]
    //[XafDefaultProperty(nameof(CoinsInfo))]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public class CharacterStorage : BaseObject
    {
        public CharacterStorage()
        {
        }

        #region Fields
        [XafDisplayName("Хранилище")]
        public string DefaultProperty => $"{Character?.Name} {Name}: {CoinsInfo}";

        [XafDisplayName("Наименование"), StringLength(150)]
        public virtual string Name { get; set; }

        [XafDisplayName("Описание"), StringLength(750)]
        public virtual string Description { get; set; }


        [XafDisplayName("Медные монеты")]
        public virtual decimal СopperСoins { get; set; }

        [XafDisplayName("Серебрянные монеты")]
        public decimal SilverCoins => СopperСoins / 10;
        [XafDisplayName("Золотые монеты")]
        public decimal GoldCoins => СopperСoins / 100;
        [XafDisplayName("Платиновые монеты")]
        public decimal PlatinumCoins => СopperСoins / 1000;

        [XafDisplayName("Деньги")]
        public string CoinsInfo =>
            $"{TruncateCoins(GoldCoins, "зм", true)}{TruncateCoins((СopperСoins % 100)/10, "см", true)}{TruncateCoins(СopperСoins % 10, "мм")}";


        [XafDisplayName("Инвентарь персонажа")]
        public virtual bool Local { get; set; }

        [Browsable(false)]
        public virtual Guid? CharacterId { get; set; }


        [ForeignKey(nameof(CharacterId))]
        [XafDisplayName("Персонаж")]
        public virtual Character? Character { get; set; }


        [Aggregated]
        [XafDisplayName("Простые Операции/Входящие")]
        public virtual IList<StorageOperation> Operations { get; set; } = new ObservableCollection<StorageOperation>();

        [Aggregated]
        [XafDisplayName("Исходящие Операции")]
        public virtual IList<StorageOperation> OperationsFromThis { get; set; } = new ObservableCollection<StorageOperation>();


        #endregion


        #region Events
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);


        }

        #endregion



        private string TruncateCoins(decimal coins, string nominal, bool addZapit = false) =>
            coins >= 1
                ? $"{Math.Truncate(coins)}{nominal}{(addZapit && Math.Truncate(coins) != coins ? ", " : "")}"
                : "";
        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}