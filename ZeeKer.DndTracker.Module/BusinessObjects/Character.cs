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
            MaxSettingCount = 3;
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

        private int GetACValue()
        {
            if(Armor > 0)
                return Armor;

            var shieldBonus = ShieldItem?.Item is not null? ((ShieldItem)ShieldItem.Item).ACBonus : 0;

            if(ArmorItem?.Item is null)
                return Stats?.DexterityBonus??0 + shieldBonus;
            var armor = ArmorItem?.Item as ArmorItem;

            switch(armor.ArmorType)
            {
                case Types.ArmorType.Heavy:
                    return armor.AC + shieldBonus;

                case Types.ArmorType.Medium:
                    return Stats?.DexterityBonus > 2? armor.AC + 2 + shieldBonus : armor.AC + Stats?.DexterityBonus??0 + shieldBonus;

                case Types.ArmorType.Light:
                    return armor.AC + Stats?.DexterityBonus??0 + shieldBonus;
                default: return Stats?.DexterityBonus??0 + shieldBonus;
            }
        }
        #endregion
    }
}