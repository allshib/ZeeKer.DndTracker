using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<Character> Characters { get; set; }" syntax.
    [DefaultClassOptions]
    [XafDisplayName("Персонаж")]
    public class Character : BaseObject
    {
        public Character()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }




        [XafDisplayName("Имя"), StringLength(150)]
        public virtual string Name { get; set; }


        [Browsable(false)]
        public virtual Guid? CampainId { get; set; }

        [XafDisplayName("Кампейн")]
        [ForeignKey(nameof(CampainId))]
        public virtual Campain? Campain { get; set; }


        [Browsable(false)]
        public virtual Guid? PersonId { get; set; }


        [ForeignKey(nameof(PersonId))]
        [XafDisplayName("Игрок")]
        public virtual Person? Person { get; set; }


        [Aggregated]
        [XafDisplayName("Хранилища")]
        public virtual IList<CharacterStorage> Storages { get; set; } = new ObservableCollection<CharacterStorage>();

        [XafDisplayName("Инвентарь")]
        public CharacterStorage LocalStorage => Storages?.FirstOrDefault(storage=>storage.Local);


        public override void OnCreated()
        {
            base.OnCreated();
            CreateLocalStorage();


        }

        public override void OnSaving()
        {
            base.OnSaving();

        }
        

        private void CreateLocalStorage()
        {
            var storage = ObjectSpace.CreateObject<CharacterStorage>();
            storage.Name = "Инвентарь";
            storage.Local = true;
            storage.Character = this;
            
        }

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}