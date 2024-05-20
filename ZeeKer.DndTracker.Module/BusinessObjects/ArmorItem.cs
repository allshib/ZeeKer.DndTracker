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

    [XafDisplayName("�����")]
    public class ArmorItem : Item
    {
        public ArmorItem()
        {
            
        }
        [XafDisplayName("��")]
        public virtual int AC {  get; set; }


        [XafDisplayName("����� �����")]
        public virtual ArmorType ArmorType { get; set; }

        public override ItemType ItemType => ItemType.Armor;
    }
}