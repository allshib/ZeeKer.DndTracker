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
    [XafDisplayName("Назначенный бонус черты")]
    [XafDefaultProperty(nameof(Bonus))]
    public class AssignedFeatBonus : BaseObject
    {
        public AssignedFeatBonus()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [Browsable(false)]
        public virtual Guid? FeatId { get; set; }


        [ForeignKey(nameof(FeatId))]
        [XafDisplayName("Черта")]
        public virtual Feat Feat { get; set; }

        [Browsable(false)]
        public virtual Guid? BonusId { get; set; }


        [ForeignKey(nameof(BonusId))]
        [XafDisplayName("Бонус")]
        public virtual BonusBase Bonus { get; set; }

        public override void OnSaving()
        {
            base.OnSaving();

            if (ObjectSpace.IsObjectToDelete(this))
                OnDeleting();
        }

        private void OnDeleting()
        {
            ObjectSpace.Delete(Bonus);
        }
    }
}