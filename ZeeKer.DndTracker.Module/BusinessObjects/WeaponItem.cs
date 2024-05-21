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
    [XafDisplayName("������")]
    public class WeaponItem : Item
    {
        public WeaponItem()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [XafDisplayName("�������� ��� �����")]
        public virtual DamageType MainDamageType { get; set; }

        [XafDisplayName("��� �������������")]
        public virtual HandWeaponType HandWeaponType {  get; set; }

        [XafDisplayName("��� ����")]
        public virtual WeightWeaponType WeightWeaponType { get; set; }

        [XafDisplayName("��� ���")]
        public virtual WeaponRangeType WeaponRangeType { get; set; }

        [XafDisplayName("������������")]
        public virtual bool Fencing { get; set; }

        [XafDisplayName("�����������")]
        public virtual bool Throwing { get; set; }

        [XafDisplayName("������")]
        public virtual bool Special { get; set; }

        public override ItemType ItemType => ItemType.Weapon;


    }
}