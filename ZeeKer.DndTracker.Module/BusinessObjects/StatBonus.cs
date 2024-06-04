﻿using DevExpress.Data.Filtering;
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

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Бонус характеристик")]
    public class StatBonus : BonusBase
    {
        public StatBonus()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        [NotMapped]
        public override string Name => $"{String.Join(" или ", BonusGroups.Select(x => x.GroupName))}";


        [XafDisplayName("Группы бонусов"), Aggregated]
        public virtual IList<StatBonusGroup> BonusGroups { get; set; } = new ObservableCollection<StatBonusGroup>();
        public override void OnCreated()
        {
            base.OnCreated();

            Type = Types.BonusType.Stat;
        }
    }
}