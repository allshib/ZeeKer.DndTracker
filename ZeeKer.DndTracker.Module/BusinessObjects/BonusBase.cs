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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Бонус")]
    [XafDefaultProperty(nameof(Name))]
    public abstract class BonusBase : BaseObject
    {
        public BonusBase()
        {
            
        }

        [StringLength(250)]
        [XafDisplayName("Название")]
        public virtual string Name { get; set; }

        [XafDisplayName("Тип")]
        public virtual BonusType Type { get; set; }
    }
}