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
    [XafDisplayName("Выбор персонажа")] 
    public class CharacterDataList : IXafEntityObject, INotifyPropertyChanged
    {

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CharacterDataList(List<CharacterData> characters)
        {
            Oid = Guid.NewGuid();
            CharacterDataItems = characters
                .Select(
                    ch => new CharacterDataItem
                        {
                            Character = ch
                        })
                .ToList();

        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)] 
        public Guid Oid { get; set; }
        [XafDisplayName("Персонажи")]
        public List<CharacterDataItem> CharacterDataItems { get; set; } = new List<CharacterDataItem>();

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