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
    [DefaultClassOptions]
    [XafDisplayName("�������� ��� ����������")]
    public class StorageOperation : BaseObject
    {
        public StorageOperation()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
            
        }
        [XafDisplayName("�������")]

        public virtual string Reason { get; set; }

        [XafDisplayName("��� ��������")]
        public virtual StorageOperationType OperationType { get; set; }

        [XafDisplayName("�����")]
        public virtual OperationMode OperationMode { get; set; }

        [XafDisplayName("���-�� �����")]
        public virtual decimal Coins { get; set; }

        [Browsable(false)]
        public virtual Guid? StorageId { get; set; }

        [ForeignKey(nameof(StorageId)), XafDisplayName("��������� ����������")]
        public virtual CharacterStorage? Storage { get; set; }

        [XafDisplayName("���� ��������")]
        public virtual DateTimeOffset? OperationDate { get; set; }


        [Browsable(false)]
        public virtual Guid? SourceStorageId { get; set; }

        [ForeignKey(nameof(SourceStorageId)), XafDisplayName("��������� ��������")]
        public virtual CharacterStorage? StorageSource { get; set; }

        public override void OnCreated()
        {
            base.OnCreated();
            OperationDate = DateTimeOffset.Now;
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