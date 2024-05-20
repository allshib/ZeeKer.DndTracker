using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraScheduler.Native;
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
    public partial class Character : BaseObject
    {
        public Character()
        {

        }
        #region Events
        public override void OnCreated()
        {
            base.OnCreated();
            CreateLocalStorage();
            var user = ObjectSpace.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            Person = user?.Person;
            Info = ObjectSpace.CreateObject<CharacterInfo>();
            Stats = ObjectSpace.CreateObject<CharacterStats>();
            Level = 1;
            CreatedAt = DateTimeOffset.Now;
        }

        public override void OnSaving()
        {
            base.OnSaving();

            if (ObjectSpace.IsObjectToDelete(this))
                OnDeleting();
            
        }

        private void OnDeleting()
        {
            ObjectSpace.Delete(Info);
        }

        #endregion

        #region Methods
        private void CreateLocalStorage()
        {
            var storage = ObjectSpace.CreateObject<CharacterStorage>();
            storage.Name = "Инвентарь";
            storage.Local = true;
            storage.Character = this;
            
        }
        #endregion
    }
}