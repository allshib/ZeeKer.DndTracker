﻿using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using Microsoft.EntityFrameworkCore;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using DevExpress.ExpressApp.WebApi.Services;
using Microsoft.AspNetCore.OData;
using ZeeKer.DndTracker.WebApi.JWT;
using DevExpress.ExpressApp.Security.Authentication.ClientServer;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using ZeeKer.DndTracker.WebApi.Services;

namespace ZeeKer.DndTracker.WebApi;

public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services) {
        services.AddScoped<IAuthenticationTokenProvider, JwtTokenProviderService>();
        services.AddHostedService<TelegramService>();

        services.AddXafWebApi(builder => {
            builder.ConfigureOptions(options => {
                // Make your business objects available in the Web API and generate the GET, POST, PUT, and DELETE HTTP methods for it.
                // options.BusinessObject<YourBusinessObject>();
            });

            builder.Modules
                .AddReports(options => {
                    options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
                })
                .AddValidation()
                .Add<ZeeKer.DndTracker.Module.DndTrackerModule>();


            builder.ObjectSpaceProviders
                .AddSecuredEFCore(options => options.PreFetchReferenceProperties())
                    .WithDbContext<Module.BusinessObjects.DndTrackerEFCoreDbContext>((serviceProvider, options) => {
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

                    options.UserType = typeof(Module.BusinessObjects.ApplicationUser);

                    options.UserLoginInfoType = typeof(Module.BusinessObjects.ApplicationUserLoginInfo);
                    options.Events.OnSecurityStrategyCreated += securityStrategy => {
                        ((SecurityStrategy)securityStrategy).PermissionsReloadMode = PermissionsReloadMode.CacheOnFirstAccess;
                    };
                })
                .AddPasswordAuthentication(options => {
                    options.IsSupportChangePassword = true;
                });

            builder.AddBuildStep(application => {
                application.ApplicationName = "DndTracker.Bot";
                application.CheckCompatibilityType = CheckCompatibilityType.ModuleInfo;
                application.DatabaseUpdateMode = DatabaseUpdateMode.Never;
            });
        }, Configuration);

        services
            .AddControllers()
            .AddOData((options, serviceProvider) => {
                options
                    .AddRouteComponents("api/odata", new EdmModelBuilder(serviceProvider).GetEdmModel())
                    .EnableQueryFeatures(100);
            });

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters() {
                    ValidateIssuerSigningKey = true,
                    //ValidIssuer = Configuration["Authentication:Jwt:Issuer"],
                    //ValidAudience = Configuration["Authentication:Jwt:Audience"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:Jwt:IssuerSigningKey"]))
                };
            });

        services.AddAuthorization(options => {
            options.DefaultPolicy = new AuthorizationPolicyBuilder(
                JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .RequireXafAuthentication()
                    .Build();
        });

        services.AddSwaggerGen(c => {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo {
                Title = "ZeeKer.DndTracker API",
                Version = "v1",
                Description = @"Use AddXafWebApi(options) in the ZeeKer.DndTracker.WebApi\Startup.cs file to make Business Objects available in the Web API."
            });
            c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme() {
                Type = SecuritySchemeType.Http,
                Name = "Bearer",
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme() {
                            Reference = new OpenApiReference() {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "JWT"
                            }
                        },
                        new string[0]
                    },
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZeeKer.DndTracker WebApi v1");
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
