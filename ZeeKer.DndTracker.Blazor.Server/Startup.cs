using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.EntityFrameworkCore;
using ZeeKer.DndTracker.Blazor.Server.Services;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Blazor.Server;

public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services) {
        services.AddSingleton(typeof(Microsoft.AspNetCore.SignalR.HubConnectionHandler<>), typeof(ProxyHubConnectionHandler<>));

        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddHttpContextAccessor();
        services.AddScoped<CircuitHandler, CircuitHandlerProxy>();
        services.AddXaf(Configuration, builder => {
            builder.UseApplication<DndTrackerBlazorApplication>();
            builder.Modules
                .AddConditionalAppearance()
                .AddDashboards(options => {
                    options.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.EF.DashboardData);
                })
                .AddFileAttachments()
                .AddOffice()
                .AddReports(options => {
                    options.EnableInplaceReports = true;
                    options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
                    options.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
                })
                .AddScheduler()
                .AddStateMachine(options => {
                    options.StateMachineStorageType = typeof(DevExpress.Persistent.BaseImpl.EF.StateMachine.StateMachine);
                })
                .AddValidation()
                .AddViewVariants()
                .Add<Module.DndTrackerModule>()
            	.Add<DndTrackerBlazorModule>();
            builder.ObjectSpaceProviders
                .AddSecuredEFCore(options => options.PreFetchReferenceProperties())
                    .WithDbContext<Module.BusinessObjects.DndTrackerEFCoreDbContext>((serviceProvider, options) => {
                        var connectionString = GetConnectionString();

                        options.UseSqlServer(
                            connectionString,
                            sqlOptions => 
                            {
                                sqlOptions.EnableRetryOnFailure();
                                sqlOptions.CommandTimeout(60); // Установка тайм-аута команды в 60 секунд
                                sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                            });

                        options.UseChangeTrackingProxies();
                        options.UseObjectSpaceLinkProxies();
                        options.UseLazyLoadingProxies();
                    })
                .AddNonPersistent();
            builder.Security
                .UseIntegratedMode(options => {
                    options.Lockout.Enabled = true;
                    options.RoleType = typeof(PermissionPolicyRole); 
                    options.UserType = typeof(Module.BusinessObjects.ApplicationUser);
                    options.UserLoginInfoType = typeof(Module.BusinessObjects.ApplicationUserLoginInfo);
                    options.Events.OnSecurityStrategyCreated += securityStrategy => {
                        var strategy = (SecurityStrategy)securityStrategy;
                        strategy.PermissionsReloadMode = PermissionsReloadMode.CacheOnFirstAccess;
                    };
                })
                .AddPasswordAuthentication(options => {
                    options.IsSupportChangePassword = true;
                });
        });
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
            options.LoginPath = "/LoginPage";
        });
    }

    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. To change this for production scenarios, see: https://aka.ms/aspnetcore-hsts.
            //app.UseHsts();
        }
        //app.UseHttpsRedirection();
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<DndTrackerEFCoreDbContext>();
            context.Database.Migrate();
        }



        app.UseRequestLocalization();
        var supportedCultures = new string[] { "ru-Ru" };
        app.UseRequestLocalization(options =>
            options
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures)
                .SetDefaultCulture("ru-Ru")
        );
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseXaf();
        app.UseEndpoints(endpoints => {
            endpoints.MapXafEndpoints();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
            endpoints.MapControllers();
        });

 
    }


    private string GetConnectionString()
    {
        string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
#if RELEASE

        if (String.IsNullOrEmpty(connectionString) &&
        Configuration.GetConnectionString("ConnectionStringRelease") is not null)
            connectionString = Configuration.GetConnectionString("ConnectionStringRelease");

#else

        if (Configuration.GetConnectionString("ConnectionString") is not null)
            connectionString = Configuration.GetConnectionString("ConnectionString");
                        
#endif
        ArgumentNullException.ThrowIfNull(connectionString);

        return connectionString;
    }
}
