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

namespace ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent
{
    [DomainComponent]
    [XafDisplayName("Элемент персонажа")]
    [XafDefaultProperty(nameof(Name))]
    public class CharacterDataItem : IXafEntityObject, INotifyPropertyChanged
    {

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CharacterDataItem()
        {
            Oid = Guid.NewGuid();
        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid Oid { get; set; }

        private bool selected;
        [XafDisplayName("Выбран")]
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    OnPropertyChanged();
                }
            }
        }

        [XafDisplayName("Имя")]
        public string Name => Character?.name?.value;

        private CharacterData character;
        [XafDisplayName("Персонаж"), Browsable(false)]
        public CharacterData Character
        {
            get { return character; }
            set
            {
                if (character != value)
                {
                    character = value;
                    OnPropertyChanged();
                }
            }
        }

        [Action(Caption = "Выбрать", SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
        public void SelectItem()
        {
            Selected = !Selected;
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

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}