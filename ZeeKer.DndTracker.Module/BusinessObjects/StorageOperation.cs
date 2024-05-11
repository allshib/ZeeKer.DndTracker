using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
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
    [DefaultClassOptions]
    [XafDisplayName("Операции над хранилищем")]
    public class StorageOperation : BaseObject
    {
        public StorageOperation()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
            
        }
        [XafDisplayName("Причина")]

        public virtual string Reason { get; set; }

        [XafDisplayName("Тип операции")]
        public virtual StorageOperationType OperationType { get; set; }

        [XafDisplayName("Режим")]
        public virtual OperationMode OperationMode { get; set; }

        [XafDisplayName("Кол-во монет")]
        public virtual decimal Coins { get; set; }

        [Browsable(false)]
        public virtual Guid? StorageId { get; set; }

        [ForeignKey(nameof(StorageId)), XafDisplayName("Хранилище Получатель")]
        public virtual CharacterStorage? Storage { get; set; }

        [XafDisplayName("Дата операции")]
        public virtual DateTimeOffset? OperationDate { get; set; }


        [Browsable(false)]
        public virtual Guid? SourceStorageId { get; set; }

        [ForeignKey(nameof(SourceStorageId)), XafDisplayName("Хранилище Источник")]
        public virtual CharacterStorage? StorageSource { get; set; }

        [Browsable(false)]
        public virtual Guid? CreatedAtId { get; set; }

        [XafDisplayName("Кем создано"), ForeignKey(nameof(CreatedAtId))]
        public virtual Person? CreatedAt { get; set; }

        [Browsable(false)]
        public virtual Guid? CampainId { get; set; }
        [XafDisplayName("Кампейн")]
        public virtual Campain? Campain { get; set; }

        [XafDisplayName("Доступные персонажи"), NotMapped]
        public virtual IEnumerable<Character> ActiveCharacters => ObjectSpace.GetObjects<Character>(CriteriaOperator.Parse($"{nameof(Character.CampainId)} = ?", CampainId));

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


        [NotMapped, Browsable(false)]
        private Character sourceCharacter;

        [NotMapped, XafDisplayName("Персонаж Отправитель")]
        public virtual Character SourceCharacter
        {
            get
            {
                return sourceCharacter;
            }
            set
            {
                sourceCharacter = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(SourceCharacter)));
            }
        }

        public override void OnCreated()
        {
            base.OnCreated();
            OperationDate = DateTimeOffset.Now;
            var user = ObjectSpace.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            CreatedAt = user.Person;
        }

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);

            if (e.PropertyName is null)
                return;



            switch (e.PropertyName)
            {
                case nameof(DestinationCharacter):
                    Storage = DestinationCharacter?.LocalStorage;
                    break;
                case nameof(SourceCharacter):
                    StorageSource = SourceCharacter?.LocalStorage;
                    break;
            }
        }

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}