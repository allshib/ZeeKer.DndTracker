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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("����� ��������������")]
    public class OneStatBonus : BaseObject
    {
        public OneStatBonus()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        [XafDisplayName("�����")]
        public virtual int StatBonus { get; set; }

        [XafDisplayName("��� ��������������")]
        public virtual StatBonusType BonusType { get; set; }

        [Browsable(false)]
        public virtual Guid? StatBonusGroupId { get; set; }

        [ForeignKey(nameof(StatBonusGroupId)), XafDisplayName("������")]
        public virtual StatBonusGroup Group { get; set; }
    }
}