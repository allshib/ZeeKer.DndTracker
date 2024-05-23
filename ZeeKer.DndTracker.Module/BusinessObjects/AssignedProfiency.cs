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
    [XafDisplayName("Владение персонажа")]
    public class AssignedProfiency : BaseObject
    {
        public AssignedProfiency()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [Browsable(false)]
        public virtual Guid? ProfiencyId { get; set; }

        [ForeignKey(nameof(ProfiencyId)), XafDisplayName("Владение")]
        public virtual Profiency Profiency { get; set; }

        [Browsable(false)]
        public virtual Guid? ItemId {get;set;}

        [ForeignKey(nameof(ItemId)), XafDisplayName("Предмет")]
        public virtual Item Item { get; set; }

        [XafDisplayName("Выбранное владение")]
        public virtual string DefaultProperty => $"{(Profiency is not null && Profiency.NeedSelectObject? $"{Item}":$"{Profiency?.Name}")}";

        public virtual Guid? CharacterId { get; set; }

        [ForeignKey(nameof(CharacterId)), XafDisplayName("Персонаж")]
        public virtual Character Character { get; set; }
        
    }
}