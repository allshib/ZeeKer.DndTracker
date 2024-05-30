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
    [XafDisplayName("Группа бонусов")]
    [XafDefaultProperty(nameof(GroupName))]
    public class StatBonusGroup : BaseObject
    {
        public StatBonusGroup()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [StringLength(100), XafDisplayName("Наименование группы")]
        public virtual string GroupName { get; set; }

        [Browsable(false)]
        public virtual Guid? StatBonusId {  get; set; }

        [ForeignKey(nameof(StatBonusId)), XafDisplayName("Бонус")]
        public virtual StatBonus Bonus { get; set; }


        [XafDisplayName("Бонусы характеристик группы"), Aggregated]
        public virtual IList<OneStatBonus> StatBonuses { get; set; } = new ObservableCollection<OneStatBonus>();
    }
}