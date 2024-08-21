using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.DndSu.Parsers;

namespace ZeeKer.DndTracker.DndSu.Extensions
{
    public static class ServiceCollectionEx
    {


        public static IServiceCollection AddDndSu(this IServiceCollection services)
        {
            services.AddScoped<ISpellParser, DndsuSpellParser>();
            services.AddScoped<IItemParser, DndsuItemParser>();
            return services;
        }
    }
}
