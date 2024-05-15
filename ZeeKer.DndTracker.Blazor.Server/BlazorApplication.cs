using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using ZeeKer.DndTracker.Module.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using DevExpress.ExpressApp.EFCore;
using DevExpress.EntityFrameworkCore.Security;

namespace ZeeKer.DndTracker.Blazor.Server;

public class DndTrackerBlazorApplication : BlazorApplication {
    public DndTrackerBlazorApplication() {
        ApplicationName = "ZeeKer.DndTracker";
        CheckCompatibilityType = CheckCompatibilityType.ModuleInfo;
        DatabaseVersionMismatch += DndTrackerBlazorApplication_DatabaseVersionMismatch;
    }
    protected override void OnSetupStarted() {
        base.OnSetupStarted();
#if DEBUG
        if(System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.ModuleInfo) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
#endif
    }
    private void DndTrackerBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
        e.Updater.Update();
        e.Handled = true;
    }
}
