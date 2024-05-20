using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeeKer.DndTracker.Module.Types;


namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Предмет")]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public abstract class Item : BaseObject
    {
        public Item()
        {
            
        }
        [XafDisplayName("Наименование"), StringLength(200)]
        public virtual string Name { get; set; }


        [XafDisplayName("Описание"), StringLength(1000)]
        public virtual string Description { get; set; }

        [XafDisplayName("Тип")]
        public virtual ItemType ItemType => ItemType.Unknown;

        [XafDisplayName("Назначения")]
        public virtual IList<AssignedItem> AssignedItems { get; set; } = new ObservableCollection<AssignedItem>();

        [XafDisplayName("Предмет"), NotMapped]
        public virtual string DefaultProperty => $"{Name}";

        [XafDisplayName("Вес")]
        public virtual double Weight { get; set; }

        [XafDisplayName("Редкость")]
        public virtual ItemRarityType Rarity { get; set; }
    }
}