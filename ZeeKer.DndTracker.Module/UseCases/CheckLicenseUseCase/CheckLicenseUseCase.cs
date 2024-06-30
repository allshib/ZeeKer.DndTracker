
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Reflection;
using System.Collections;


namespace ZeeKer.DndTracker.Module.UseCases.CheckLicenseUseCase
{
    internal class CheckLicenseUseCase : ShowViewUseCaseBase
    {
        public CheckLicenseUseCase(XafApplication application) : base(application)
        {
        }

        public void Execute()
        {
            var field = typeof(LicenseManager).GetField("s_providers", BindingFlags.NonPublic | BindingFlags.Static);
            var providers = field.GetValue(null) as Hashtable;
            var licenses = new List<LicenseViewModel>();

            foreach (var key in providers.Keys)
            {
                licenses.Add(new LicenseViewModel()
                {
                    LicenseProvider = providers[key]?.GetType().Name,
                    Type = key.ToString()
                });
            }

            //var os = application.CreateObjectSpace(typeof(LincesesViewModel));
            var entity = new LincesesViewModel(licenses);
            var os = application.CreateObjectSpace(typeof(LicenseViewModel));
            var dv = this.CreateDetailView(entity, os);

            this.OpenDetailView(dv);
        }
    }
}
