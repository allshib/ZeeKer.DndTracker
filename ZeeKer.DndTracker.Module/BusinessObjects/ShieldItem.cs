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
    [XafDisplayName("Щит")]
    public class ShieldItem : Item
    {
        public ShieldItem()
        {
            
        }


        [XafDisplayName("КЗ Бонус")]
        public virtual int ACBonus { get; set; }

        public override ItemType ItemType => ItemType.ShieldItem;

        public override string DefaultProperty => $"{Name} ({ACBonus})";

        public override void OnCreated()
        {
            base.OnCreated();
            ACBonus = 2;
        }
    }
}