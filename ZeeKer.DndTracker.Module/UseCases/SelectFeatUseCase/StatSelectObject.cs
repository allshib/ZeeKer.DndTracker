using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.SelectFeatUseCase
{
    [DomainComponent]
    [XafDisplayName("Выбор бонуса характеристик")]
    public class StatSelectObject : IXafEntityObject/*, IObjectSpaceLink*/, INotifyPropertyChanged
    {
        //private IObjectSpace objectSpace;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public StatSelectObject()
        {
            Oid = Guid.NewGuid();
        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]
        public Guid Oid { get; set; }

        private int bonus;
        [XafDisplayName("Бонус")]
        public int Bonus
        {
            get { return bonus; }
            set
            {
                if (bonus != value)
                {
                    bonus = value;
                    OnPropertyChanged();
                }
            }
        }
        

        private StatBonusType bonusType;
        [XafDisplayName("Тип бонуса")]
        public StatBonusType BonusType
        {
            get { return bonusType; }
            set
            {
                if (bonusType != value)
                {
                    bonusType = value;
                    OnPropertyChanged();
                }
            }
        }


        #region IXafEntityObject
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.
        }
        #endregion

        #region IObjectSpaceLink members
        // If you implement this interface, handle the NonPersistentObjectSpace.ObjectGetting event and find or create a copy of the source object in the current Object Space.
        // Use the Object Space to access other entities (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        //IObjectSpace IObjectSpaceLink.ObjectSpace {
        //    get { return objectSpace; }
        //    set { objectSpace = value; }
        //}
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}