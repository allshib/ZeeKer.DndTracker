using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.Extensions
{
    internal static class StorageOperationEx
    {

        public static void ExecuteOperation(this StorageOperation operation)
        {
            if(operation is null) 
                throw new ArgumentNullException(nameof(operation));

            if (operation.Executed)
                throw new UserFriendlyException("Операция уже была выполнена");

            switch (operation.OperationType)
            {
                case StorageOperationType.AddGoldCoins:
                    var addGoldCoins = operation.Coins * 100;

                    operation.Storage!.CopperCoins += addGoldCoins;

                    if (operation.SourceStorageId is not null)
                        operation.StorageSource!.CopperCoins -= addGoldCoins;
                    break;
                case StorageOperationType.RemoveGoldCoins:
                    operation.Storage!.CopperCoins -= operation.Coins * 100;
                    break;
                case StorageOperationType.AddSilverCoins:
                    var addSilverCoins = operation.Coins * 10;

                    operation.Storage!.CopperCoins += addSilverCoins;

                    if (operation.SourceStorageId is not null)
                        operation.StorageSource!.CopperCoins -= addSilverCoins;
                    break;
                case StorageOperationType.RemoveSilverCoins:
                    operation.Storage!.CopperCoins -= operation.Coins * 10;
                    break;
                case StorageOperationType.AddCopperCoins:
                    operation.Storage!.CopperCoins += operation.Coins;

                    if (operation.SourceStorageId is not null)
                        operation.StorageSource!.CopperCoins -= operation.Coins;
                    break;
                case StorageOperationType.RemoveCopperCoins:
                    operation.Storage!.CopperCoins -= operation.Coins;
                    break;
                default:
                    throw new NotImplementedException();

            }
            operation.Executed = true;
        }
    }
}
