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
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.DndSu.Parsers;
using ZeeKer.DndTracker.Module.UseCases.LoadSpellsUseCase;
using ZeeKer.DndTracker.Module.UseCases.GetDndSuLinkBySpellNameUseCase;
using ZeeKer.DndTracker.Module.UseCases.UpdateSpellUseCase;
using ZeeKer.DndTracker.DndSu.Extensions;
using ZeeKer.DndTracker.Module.Extensions;
using ZeeKer.DndTracker.Blazor.Server.Extensions;
namespace ZeeKer.DndTracker.Blazor.Server;

public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services) {
        services.AddBlazorServices();

        services.AddDndSu();
        services.AddDndTrackerModule();
        


        
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
                .AddEFCore(options => options.PreFetchReferenceProperties())
                    .WithDbContext<DndTrackerEFCoreDbContext>((serviceProvider, options) => {
                        var connectionString = GetConnectionString();

                        options.UseSqlServer(
                            connectionString,
                            sqlOptions => 
                            {
                                sqlOptions.EnableRetryOnFailure();
                                sqlOptions.CommandTimeout(120); // Установка тайм-аута команды в 60 секунд
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
                    options.UserType = typeof(ApplicationUser);
                    options.UserLoginInfoType = typeof(ApplicationUserLoginInfo);
                    options.Events.OnSecurityStrategyCreated += securityStrategy => {
                        var strategy = (SecurityStrategy)securityStrategy;
                        strategy.PermissionsReloadMode = PermissionsReloadMode.CacheOnFirstAccess;
                    };
                })
                .AddPasswordAuthentication(options => {
                    options.IsSupportChangePassword = true;
                });
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
