using DevExpress.Pdf.Native.BouncyCastle.Asn1.X509;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.Mappers
{

    [Mapper]
    public static partial class StorageMapperEx
    {


        [MapperIgnoreSource(nameof(CharacterStorage.ID))]
        [MapperIgnoreTarget(nameof(CharacterStorage.ID))]
        public static partial void MapTo(this CharacterStorage source, CharacterStorage target);


        public static void CustomMapTo(this CharacterStorage source, CharacterStorage target)
        {
            var osTarget = target.GetObjectSpace();
            source.MapTo(target);

            foreach (var item in source.Items)
            {
                var newItem = target.Items.FirstOrDefault(x => x.ItemId == item.ItemId) ??
                    osTarget.CreateObject<AssignedItem>();

                newItem.ItemId = item.ItemId;
                newItem.Count = item.Count;
                newItem.Storage = target;
                newItem.CurrentNumberOfUses = item.CurrentNumberOfUses;
                newItem.SettingOnThis = item.SettingOnThis;
            }
        }
    }
}
