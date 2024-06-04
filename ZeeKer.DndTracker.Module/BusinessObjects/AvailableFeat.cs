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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{

    [XafDisplayName("��������� �����")]
    [XafDefaultProperty(nameof(Name))]
    public class AvailableFeat : BaseObject
    {
        public AvailableFeat()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [Browsable(false)]
        public virtual Guid? FeatId { get; set; }

        [Browsable(false)]
        public virtual Guid? CharacterId { get; set; }

        [ForeignKey(nameof(CharacterId)), XafDisplayName("��������")]
        public virtual Character Character { get; set; }


        [XafDisplayName("��������"), StringLength(100)]
        public virtual string Name { get; set; }

        [XafDisplayName("��������"), StringLength(1500)]
        public virtual string Description { get; set; }


        [XafDisplayName("������� ����������")]
        public virtual int LevelAdded { get; set; }

        [XafDisplayName("����������� ������")]
        public virtual AvailableFeatJson SelectedBonuses { get; set; }


        [Action(Caption = "������ �����", ConfirmationMessage = "�� �������?", SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
        public void RollbackFeat()
        {
            this.Rollback();
        }
    }
}