using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.Extensions
{
    internal static class OperationTypeEx
    {
        public static string GetEnumRuText(this StorageOperationType operationType) => operationType switch
        {
            StorageOperationType.AddSilverCoins => "Добавить серебрянные монеты",
            StorageOperationType.AddGoldCoins => "Добавить золотые монеты",
            StorageOperationType.RemoveGoldCoins => "Вычесть золотые монеты",
            StorageOperationType.RemoveSilverCoins => "Вычесть серебрянные монеты",
            StorageOperationType.AddCopperCoins => "Добавить медные монеты",
            StorageOperationType.RemoveCopperCoins => "Вычесть медные монеты",
            StorageOperationType.AddItems => "Добавить предметы",
            _ => "Not Implemented"
        };
        

        
    }
}
