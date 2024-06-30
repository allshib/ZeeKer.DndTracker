using DevExpress.ExpressApp.SystemModule;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

using DevExpress.XtraReports.UI;
using DevExpress.Utils.About;
namespace ZeeKer.DndTracker.Blazor.Server.Helpers;

public static class BlazorLicenseHelper
{

    public static void ActivateLicense()
    {
        var providersField = typeof(LicenseManager).GetField("s_providers", BindingFlags.NonPublic | BindingFlags.Static);

        var providersTable = new Hashtable();
        providersTable.Add(typeof(SystemModule), new ZeekerLicenseProvider());
        providersTable.Add(typeof(XtraReport), new ZeekerLicenseProvider());
        providersTable.Add(typeof(DevExpressServiceCollectionExtensions), new ZeekerLicenseProvider()); 
        providersTable.Add(
            typeof(DevExpress.Blazor.Reporting.DxReportViewer).Assembly.GetType("Microsoft.Extensions.DependencyInjection.StartupExtensions"), 
            new ZeekerLicenseProvider());
                
        providersField.SetValue(null, providersTable);  
    }

    public class ZeekerLicenseProvider : LicenseProvider
    {
        public override License GetLicense(LicenseContext context, System.Type type, object instance, bool allowExceptions)
        => new DXLicense(DXLicenseType.Full);
    }

}


