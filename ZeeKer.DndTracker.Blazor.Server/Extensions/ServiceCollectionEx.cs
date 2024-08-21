using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.Circuits;
using ZeeKer.DndTracker.Blazor.Server.Services;

namespace ZeeKer.DndTracker.Blazor.Server.Extensions
{
    public static class ServiceCollectionEx
    {


        public static IServiceCollection AddBlazorServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(Microsoft.AspNetCore.SignalR.HubConnectionHandler<>), typeof(ProxyHubConnectionHandler<>));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();
            services.AddScoped<CircuitHandler, CircuitHandlerProxy>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => {
                        options.LoginPath = "/LoginPage";
                        options.ExpireTimeSpan = TimeSpan.FromDays(14); });
            return services;
        }
    }
}
