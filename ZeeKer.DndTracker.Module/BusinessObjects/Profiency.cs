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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Владение")]
    [XafDefaultProperty(nameof(Name))]
    public class Profiency : BaseObject
    {
        public Profiency()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }


        [XafDisplayName("Наименование"), StringLength(150)]
        public virtual string Name { get; set; }

        [XafDisplayName("Владение")]
        public virtual ProficiencyType ProfiencyType { get; set; }

        [XafDisplayName("Требует выбор конкрентого предмета")]
        public virtual bool NeedSelectObject { get; set; }

        [XafDisplayName("Группа умения")]
        public virtual GroupProfiencyType GroupProfiencyType { get; set;}


        [XafDisplayName("Предметы")]
        public virtual IList<Item> Items { get; set; } = new ObservableCollection<Item>();
    }
}