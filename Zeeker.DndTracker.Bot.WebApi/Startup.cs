using DevExpress.Persistent.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DevExpress.ExpressApp.WebApi.Services;
using Microsoft.AspNetCore.OData;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using ZeeKer.DndTracker.WebApi.Services;
using Microsoft.AspNetCore;
using Telegram.Bot;
using Zeeker.DndTracker.Bot.WebApi.Services;


namespace Zeeker.DndTracker.Bot.WebApi;

public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services) {

        var botConfigSection = Configuration.GetSection("BotConfiguration");
        services.Configure<BotConfiguration>(botConfigSection);
        services.AddHttpClient("tgwebhook").RemoveAllLoggers().AddTypedClient<ITelegramBotClient>(
            httpClient => new TelegramBotClient(botConfigSection.Get<BotConfiguration>()!.BotToken, httpClient));
        services.AddSingleton<UpdateHandler>();
        services.ConfigureTelegramBotMvc();


        services.AddXafWebApi(builder => {
            builder.ConfigureOptions(options => {
                // Make your business objects available in the Web API and generate the GET, POST, PUT, and DELETE HTTP methods for it.
                // options.BusinessObject<YourBusinessObject>();
            });

            builder.Modules
                .Add<ZeeKer.DndTracker.Module.DndTrackerModule>()
                .AddReports(options =>
                {
                    options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
                });

            builder.ObjectSpaceProviders
                .AddEFCore(options => options.PreFetchReferenceProperties())
                    .WithDbContext<ZeeKer.DndTracker.Module.BusinessObjects.DndTrackerEFCoreDbContext>((serviceProvider, options) => {
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

            builder.AddBuildStep(application => {
                application.ApplicationName = "ZeeKer.DndTracker";
                application.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.ModuleInfo;
            });
        }, Configuration);

        services
            .AddControllers()
            .AddOData((options, serviceProvider) => {
                options
                    .AddRouteComponents("api/odata", new EdmModelBuilder(serviceProvider).GetEdmModel())
                    .EnableQueryFeatures(100);
            });

        services.AddSwaggerGen(c => {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo {
                Title = "Zeeker.DndTracker.Bot API",
                Version = "v1",
                Description = @"Use AddXafWebApi(options) in the Zeeker.DndTracker.Bot.WebApi\Startup.cs file to make Business Objects available in the Web API."
            });
        });

        services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(o => {
            o.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if(env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zeeker.DndTracker.Bot WebApi v1");
            });
        }
        else {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. To change this for production scenarios, see: https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseRequestLocalization();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
            endpoints.MapXafEndpoints();
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
