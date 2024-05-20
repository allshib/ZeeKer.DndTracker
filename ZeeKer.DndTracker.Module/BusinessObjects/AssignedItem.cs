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

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("����������� �������")]
    [XafDefaultProperty(nameof(Name))]
    public class AssignedItem : BaseObject
    {
        public AssignedItem()
        {
            
        }
        [Browsable(false)]
        public virtual Guid? StorageId { get; set; }
        [ForeignKey(nameof(StorageId)), XafDisplayName("���������")]
        public virtual CharacterStorage Storage { get; set; }


        [Browsable(false)]
        public virtual Guid? ItemId { get; set; }
        [ForeignKey(nameof(ItemId)), XafDisplayName("�������")]
        public virtual Item Item { get; set; }

        [XafDisplayName("����������")]
        public virtual int Count {  get; set; }

        [XafDisplayName("������������")]
        public virtual string Name => $"{Item?.DefaultProperty}";

        public override void OnCreated()
        {
            base.OnCreated();
            Count = 1;
        }
    }
}