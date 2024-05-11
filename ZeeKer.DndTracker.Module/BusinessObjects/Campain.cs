using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Office;
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
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<Campain> Campains { get; set; }" syntax.
    [DefaultClassOptions]
    [XafDisplayName("Кампейн")]
    public class Campain : BaseObject
    {
        public Campain()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        // You can use the regular Code First syntax.
        // Property change notifications will be created automatically.
        // (see https://learn.microsoft.com/en-us/ef/core/change-tracking/change-detection#change-tracking-proxies for details)
        [XafDisplayName("Название"), StringLength(150)]
        public virtual string Name { get; set; }

        [Browsable(false)]
        public virtual Guid? GameMasterId { get; set; }

        [ForeignKey(nameof(GameMasterId))]
        public virtual Person? GameMaster { get; set; }

        //[Browsable(false)]
        [Aggregated]
        [XafDisplayName("Персонажи")]
        public virtual IList<Character> Characters { get; set; } = new ObservableCollection<Character>();



        // Alternatively, specify more UI options:
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), VisibleInListView(false)]
        //[RuleRequiredField(DefaultContexts.Save)]
        //public virtual string Name { get; set; }

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}