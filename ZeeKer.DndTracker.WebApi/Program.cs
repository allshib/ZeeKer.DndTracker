using System.Reflection;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.AspNetCore.DesignTime;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Utils;

namespace ZeeKer.DndTracker.WebApi;

public class Program : IDesignTimeApplicationFactory {
    public static int Main(string[] args) {
            FrameworkSettings.DefaultSettingsCompatibilityMode = FrameworkSettingsCompatibilityMode.Latest;
            SecurityStrategy.AutoAssociationReferencePropertyMode = ReferenceWithoutAssociationPermissionsMode.AllMembers;
            var host = CreateHostBuilder(args).Build();
            host.Run();
        return 0;
    }
    XafApplication IDesignTimeApplicationFactory.Create() {
        IHostBuilder hostBuilder = CreateHostBuilder(Array.Empty<string>());
        return DesignTimeApplicationFactoryHelper.Create(hostBuilder);
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
}
