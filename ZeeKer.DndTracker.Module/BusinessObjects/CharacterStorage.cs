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
    [XafDisplayName("���������")]
    //[XafDefaultProperty(nameof(CoinsInfo))]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public class CharacterStorage : BaseObject
    {
        public CharacterStorage()
        {
        }

        #region Fields
        [XafDisplayName("���������")]
        public string DefaultProperty => $"{Character?.Name} {Name}: {CoinsInfo}";

        [XafDisplayName("������������"), StringLength(150)]
        public virtual string Name { get; set; }

        [XafDisplayName("��������"), StringLength(750)]
        public virtual string Description { get; set; }


        [XafDisplayName("������ ������")]
        public virtual decimal �opper�oins { get; set; }

        [XafDisplayName("����������� ������")]
        public decimal SilverCoins => �opper�oins / 10;
        [XafDisplayName("������� ������")]
        public decimal GoldCoins => �opper�oins / 100;
        [XafDisplayName("���������� ������")]
        public decimal PlatinumCoins => �opper�oins / 1000;

        [XafDisplayName("������")]
        public string CoinsInfo =>
            $"{TruncateCoins(GoldCoins, "��", true)}{TruncateCoins((�opper�oins % 100)/10, "��", true)}{TruncateCoins(�opper�oins % 10, "��")}";


        [XafDisplayName("��������� ���������")]
        public virtual bool Local { get; set; }

        [Browsable(false)]
        public virtual Guid? CharacterId { get; set; }


        [ForeignKey(nameof(CharacterId))]
        [XafDisplayName("��������")]
        public virtual Character? Character { get; set; }


        [Aggregated]
        [XafDisplayName("������� ��������/��������")]
        public virtual IList<StorageOperation> Operations { get; set; } = new ObservableCollection<StorageOperation>();

        [Aggregated]
        [XafDisplayName("��������� ��������")]
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