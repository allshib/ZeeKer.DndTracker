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
    [XafDisplayName("��������")]
    [XafDefaultProperty(nameof(Name))]
    public class Profiency : BaseObject
    {
        public Profiency()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }


        [XafDisplayName("������������"), StringLength(150)]
        public virtual string Name { get; set; }

        [XafDisplayName("��������")]
        public virtual ProficiencyType ProfiencyType { get; set; }

        [XafDisplayName("������� ����� ����������� ��������")]
        public virtual bool NeedSelectObject { get; set; }

        [XafDisplayName("������ ������")]
        public virtual GroupProfiencyType GroupProfiencyType { get; set;}


        [XafDisplayName("��������")]
        public virtual IList<Item> Items { get; set; } = new ObservableCollection<Item>();
    }
}