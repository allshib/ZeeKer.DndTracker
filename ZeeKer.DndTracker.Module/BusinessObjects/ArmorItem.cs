﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
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
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{

    [XafDisplayName("Броня")]
    public class ArmorItem : Item
    {
        public ArmorItem()
        {
            
        }
        [XafDisplayName("КЗ")]
        public virtual int AC {  get; set; }


        [XafDisplayName("Класс брони")]
        public virtual ArmorType ArmorType { get; set; }

        public override ItemType ItemType => ItemType.Armor;

        [NotMapped]
        public override string DefaultProperty => $"{Name}, Тип: {CaptionHelper.GetDisplayText(ArmorType)}, КЗ: {AC}";
    }
}