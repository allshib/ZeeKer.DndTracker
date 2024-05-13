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

namespace ZeeKer.DndTracker.Module.BusinessObjects
{

    //[DefaultProperty("Name")]
    [XafDisplayName("���������� � ���������")]
    public class CharacterInfo : BaseObject
    {
        
        public CharacterInfo()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }
        [XafDisplayName("�������")]
        public virtual int Age { get; set; }
        [XafDisplayName("���� (��)")]
        public virtual int Height { get; set; }
        [XafDisplayName("��� (��)")]
        public virtual double Weight { get; set; }
        [XafDisplayName("�����������"), StringLength(2000)]
        public virtual string Background { get; set; }

        [XafDisplayName("����� ���������"), StringLength(1000)]
        public virtual string Personality { get; set; }

        [XafDisplayName("������"), StringLength(800)]
        public virtual string Ideals { get; set; }

        [XafDisplayName("������"), StringLength(1000)]
        public virtual string Flaws { get; set; }

        [XafDisplayName("������������"), StringLength(50)]
        public virtual string Aligment { get; set; }

        [XafDisplayName("�����"), StringLength(50)]
        public virtual string Eyes { get; set; }

        [XafDisplayName("������"), StringLength(50)]
        public virtual string Hair { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}