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
    public static partial class StorageMapperEx
    {


        [MapperIgnoreSource(nameof(CharacterStorage.ID))]
        [MapperIgnoreTarget(nameof(CharacterStorage.ID))]
        public static partial void MapTo(this CharacterStorage source, CharacterStorage target);
    }
}
