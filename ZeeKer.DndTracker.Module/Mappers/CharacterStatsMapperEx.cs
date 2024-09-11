using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Mappers
{

    [Mapper]
    public static partial class StatsMapperEx
    {


        [MapperIgnoreSource(nameof(CharacterStats.ID))]
        [MapperIgnoreTarget(nameof(CharacterStats.ID))]
        public static partial void MapTo(this CharacterStats source, CharacterStats target);
    }
}
