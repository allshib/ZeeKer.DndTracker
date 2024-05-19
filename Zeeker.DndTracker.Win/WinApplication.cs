using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using Microsoft.EntityFrameworkCore;
using DevExpress.ExpressApp.EFCore;
using DevExpress.EntityFrameworkCore.Security;
using ZeeKer.DndTracker.Module;
using ZeeKer.DndTracker.Module.BusinessObjects;
using System.Data.Common;

namespace Zeeker.DndTracker.Win;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Win.WinApplication._members
public class DndTrackerWindowsFormsApplication : WinApplication {
    public DndTrackerWindowsFormsApplication() {
		SplashScreen = new DXSplashScreen(typeof(XafSplashScreen), new DefaultOverlayFormOptions());
        ApplicationName = "ZeeKer.DndTracker";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.ModuleInfo;
        UseOldTemplates = false;
        DatabaseVersionMismatch += DndTrackerWindowsFormsApplication_DatabaseVersionMismatch;
        CustomizeLanguagesList += DndTrackerWindowsFormsApplication_CustomizeLanguagesList;
    }
    private void DndTrackerWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e) {
        string userLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
        if(userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1) {
            e.Languages.Add(userLanguageName);
        }
    }
    private void DndTrackerWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
        e.Updater.Update();
        e.Handled = true;
    }
}
