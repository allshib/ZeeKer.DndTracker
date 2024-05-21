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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Оружие")]
    public class WeaponItem : Item
    {
        public WeaponItem()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [XafDisplayName("Основной тип урона")]
        public virtual DamageType MainDamageType { get; set; }

        [XafDisplayName("Тип использования")]
        public virtual HandWeaponType HandWeaponType {  get; set; }

        [XafDisplayName("Тип веса")]
        public virtual WeightWeaponType WeightWeaponType { get; set; }

        [XafDisplayName("Тип боя")]
        public virtual WeaponRangeType WeaponRangeType { get; set; }

        [XafDisplayName("Фехтовальное")]
        public virtual bool Fencing { get; set; }

        [XafDisplayName("Метательное")]
        public virtual bool Throwing { get; set; }

        [XafDisplayName("Особое")]
        public virtual bool Special { get; set; }

        public override ItemType ItemType => ItemType.Weapon;


    }
}