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

using System.ComponentModel.DataAnnotations;
using ZeeKer.DndTracker.Module.Types;


namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("�������")]
    public class Item : BaseObject
    {
        public Item()
        {
            
        }
        [XafDisplayName("������������"), StringLength(200)]
        public virtual string Name { get; set; }


        [XafDisplayName("��������"), StringLength(1000)]
        public virtual string Description { get; set; }

        [XafDisplayName("���")]
        public virtual ItemType ItemType => ItemType.Unknown;

        [XafDisplayName("����������")]
        public virtual IList<AssignedItem> AssignedItems { get; set; } = new ObservableCollection<AssignedItem>();

    }
}