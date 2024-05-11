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
using DevExpress.Office.PInvoke;
using ZeeKer.DndTracker.Module.Types;
using System.ComponentModel.DataAnnotations;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<Person> Persons { get; set; }" syntax.
    [DefaultClassOptions]


    [XafDisplayName("Игрок")]
    public class Person : BaseObject
    {
        public Person()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        [XafDisplayName("Имя"), StringLength(150)]
        public virtual string Name { get; set; }

        [XafDisplayName("Фамилия"), StringLength(150)]
        public virtual string Surname { get; set; }

        [Browsable(false)]
        public virtual Guid? UserId { get; set; }


        [ForeignKey(nameof(UserId))]
        [XafDisplayName("Пользователь")]
        [RuleRequiredField(DefaultContexts.Save)]
        public virtual ApplicationUser? User { get; set; }

        [XafDisplayName("Персонажи")]
        public virtual IList<Character> Characters { get; set; } = new ObservableCollection<Character>();




        //[XafDisplayName("Тип")]
        //public virtual PersonType PersonType { get; set; }


        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}