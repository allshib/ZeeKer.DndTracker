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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeeKer.DndTracker.Module.Types;


namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Предмет (Базовый)")]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public abstract class Item : BaseObject
    {
        public Item()
        {

        }
        [XafDisplayName("Наименование"), StringLength(200)]
        public virtual string Name { get; set; }

        [XafDisplayName("Оригинальное название"), StringLength(200)]
        public virtual string EnglishName { get; set; }


        [XafDisplayName("Описание"), StringLength(4500)]
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

        [Browsable(false)]
        public virtual Guid? ProfiencyId { get; set; }


        [ForeignKey(nameof(ProfiencyId)), XafDisplayName("Требуемое владение")]
        public virtual Profiency Profiency { get; set; }


        [XafDisplayName("Нужна настройка")]
        public virtual bool NeedSetting { get; set; }


        [XafDisplayName("Число зарядов")]
        public virtual int MaxNumbersOfUses { get; set; }

        [XafDisplayName("Ссылка Dndsu"), StringLength(150)]
        public virtual string DndsuLink { get; set; }

        [XafDisplayName("Категория")]
        public virtual Contracts.Types.ItemType Category {get;set;}

        [XafDisplayName("Источник")]
        public virtual SourceType Source { get; set; }


        [XafDisplayName("Статус загрузки")]
        public virtual LoadSpellResult LoadResult { get; set; }
    }
}