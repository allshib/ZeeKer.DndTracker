using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("�����")]
    [XafDefaultProperty(nameof(Name))]
    public class Feat : BaseObject
    {
        public Feat()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [StringLength(100)]
        [XafDisplayName("��������")]
        public virtual string Name { get; set; }

        [StringLength(1500)]
        [XafDisplayName("��������")]
        public virtual string Description { get; set; }

        [Browsable(false), NotMapped]
        public virtual Type CharacterType => typeof(Character);

        [StringLength(700)]
        [XafDisplayName("�������"), CriteriaOptions(nameof(CharacterType))]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public virtual string Condition { get; set; }

        [XafDisplayName("����� �������"),StringLength(300)]
        public virtual string ConditionText { get; set; }

        [XafDisplayName("������"), Aggregated]
        public virtual IList<AssignedFeatBonus> Bonuses { get; set; } = new ObservableCollection<AssignedFeatBonus>();
    }
}