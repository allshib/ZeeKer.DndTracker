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
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.FastAddFeatStatBonusUseCase
{
    [DomainComponent]
    [XafDisplayName("Быстрое добавление бонуса характеристик")]
    public class FastAddFeatBonusViewModel : IXafEntityObject/*, IObjectSpaceLink*/, INotifyPropertyChanged
    {
        //private IObjectSpace objectSpace;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public FastAddFeatBonusViewModel(Feat feat)
        {
            Oid = Guid.NewGuid();
            this.Feat = feat;
        }

        private Feat feat;
        [XafDisplayName("Черта")]

        public Feat Feat
        {
            get { return feat; }
            set
            {
                if (feat != value)
                {
                    feat = value;
                    OnPropertyChanged();
                }
            }
        }




        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid Oid { get; set; }

        private StatBonusType statBonusType;
        [XafDisplayName("Тип характеристики")]

        public StatBonusType StatBonusType
        {
            get { return statBonusType; }
            set
            {
                if (statBonusType != value)
                {
                    statBonusType = value;
                    OnPropertyChanged();
                }
            }
        }

        private int value;
        [XafDisplayName("Бонус")]

        public int Value
        {
            get { return value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged();
                }
            }
        }

        #region IXafEntityObject
        void IXafEntityObject.OnCreated()
        {
            
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

        #region IObjectSpaceLink
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