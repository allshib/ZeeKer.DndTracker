using DevExpress.CodeParser;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.UseCases.CreateWeaponUseCase;
using ZeeKer.DndTracker.Module.UseCases.GetDndSuLinkBySpellNameUseCase;
using ZeeKer.DndTracker.Module.UseCases.LoadItemsUseCase;
using ZeeKer.DndTracker.Module.UseCases.LoadSpellsUseCase;
using ZeeKer.DndTracker.Module.UseCases.UpdateSpellUseCase;

namespace ZeeKer.DndTracker.Module.Extensions
{
    public static class ServiceCollectionEx
    {


        public static IServiceCollection AddDndTrackerModule(this IServiceCollection services)
        {
            services.AddScoped<ILoadSpellUseCase, LoadSpellsUseCase>();
            services.AddScoped<IGetDndSuLinkBySpellNameUseCase, GetDndSuLinkBySpellNameUseCase>();
            services.AddScoped<IUpdateSpellUseCase, UpdateSpellUseCase>();
            services.AddScoped<ILoadItemsUseCase, LoadItemsUseCase>();
            //services.AddScoped<ICreateWeaponUseCase, CreateWeaponUseCase>();

            return services;
        }
    }
}
