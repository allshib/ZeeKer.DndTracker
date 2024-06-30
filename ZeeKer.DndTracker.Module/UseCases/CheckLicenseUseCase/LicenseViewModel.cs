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

namespace ZeeKer.DndTracker.Module.UseCases.CheckLicenseUseCase
{
    [DomainComponent]
    [XafDisplayName("Лицензия")]
    [XafDefaultProperty(nameof(Type))]
    public class LicenseViewModel : IXafEntityObject, INotifyPropertyChanged
    {
       
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LicenseViewModel()
        {
            Oid = Guid.NewGuid();
        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid Oid { get; set; }

        private string type;
        [XafDisplayName("Тип продукта")]
        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged();
                }
            }
        }


        private string licenseProvider;
        [XafDisplayName("Провайдер")]
        [ModelDefault("AllowEdit", "false")]

        public string LicenseProvider
        {
            get { return licenseProvider; }
            set
            {
                if (licenseProvider != value)
                {
                    licenseProvider = value;
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


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}