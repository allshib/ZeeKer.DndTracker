using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Extensions;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{

    //[DefaultClassOptions]
    [XafDisplayName("Настройки транзакции")]
    
    public class TransactionSettings : BaseObject
    {
        public TransactionSettings()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
            //DestinationCharacter = StorageDestination?.Character;
        }
        [Browsable(false)]
        public virtual Guid? TransactionId { get; set; }

        [ForeignKey(nameof(TransactionId)), XafDisplayName("Транзакция")]
        public virtual MultipleTransaction? Transaction {  get; set; }

        [XafDisplayName("Тип операции")]
        public virtual StorageOperationType OperationType { get; set; }

        [XafDisplayName("Кол-во монет")]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal Coins { get; set; }
        [NotMapped, XafDisplayName("Инфо")]
        public virtual string ShortOperationInfo => $"{OperationType.GetEnumRuText()} ({Convert.ToInt32(Coins)})";

        [NotMapped, XafDisplayName("Инфо+Получ")]
        public virtual string ShortOperationInfoAndDestination => $"{ShortOperationInfo}{(StorageDestinationId is null ? "" : $" Для \"{StorageDestination.DefaultProperty}\"")}";


        [NotMapped, Browsable(false)]
        private Character destinationCharacter;

        [NotMapped, XafDisplayName("Персонаж получатель")]
        public virtual Character DestinationCharacter
        {
            get
            {
                return destinationCharacter;
            }
            set
            {
                destinationCharacter = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(DestinationCharacter)));
            }
        }
        [Browsable(false)]
        public virtual Guid? StorageDestinationId { get; set; }
        [ForeignKey(nameof(StorageDestinationId)), XafDisplayName("Хранилище Получатель")]
        public virtual CharacterStorage? StorageDestination { get; set; }


        
        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);

            if (e.PropertyName is null)
                return;



            switch (e.PropertyName)
            {
                case nameof(DestinationCharacter):
                    StorageDestination = DestinationCharacter?.LocalStorage;
                    break;
            }

        }
        // Alternatively, specify more UI options:
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), VisibleInListView(false)]
        //[RuleRequiredField(DefaultContexts.Save)]
        //public virtual string Name { get; set; }

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}