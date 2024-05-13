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

            if (operation.Executed && operation.IsNewObject() == false)
                throw new UserFriendlyException("Операция уже была выполнена");

            switch (operation.OperationType)
            {
                case StorageOperationType.AddGoldCoins:
                    AddCoinsToDestinationFromSource(operation, operation.Coins * 100);
                    break;
                case StorageOperationType.RemoveGoldCoins:
                    operation.Storage!.CopperCoins -= operation.Coins * 100;
                    break;
                case StorageOperationType.AddSilverCoins:
                    AddCoinsToDestinationFromSource(operation, operation.Coins * 10);
                    break;
                case StorageOperationType.RemoveSilverCoins:
                    operation.Storage!.CopperCoins -= operation.Coins * 10;
                    break;
                case StorageOperationType.AddCopperCoins:
                    AddCoinsToDestinationFromSource(operation, operation.Coins);
                    break;
                case StorageOperationType.RemoveCopperCoins:
                    operation.Storage!.CopperCoins -= operation.Coins;
                    break;
                default:
                    throw new NotImplementedException();

            }
            operation.Executed = true;
        }

        public static void RollbackOperation(this StorageOperation operation)
        {
            if (operation is null)
                throw new ArgumentNullException(nameof(operation));

            if (operation.Executed == false)
                throw new UserFriendlyException("Отменить можно только примененную операцию");

            switch (operation.OperationType)
            {
                case StorageOperationType.AddGoldCoins:
                    RollbackAddOperation(operation, operation.Coins * 100);
                    break;
                case StorageOperationType.RemoveGoldCoins:
                    operation.Storage!.CopperCoins += operation.Coins * 100;
                    break;
                case StorageOperationType.AddSilverCoins:
                    RollbackAddOperation(operation, operation.Coins * 10);
                    break;
                case StorageOperationType.RemoveSilverCoins:
                    operation.Storage!.CopperCoins += operation.Coins * 10;
                    break;
                case StorageOperationType.AddCopperCoins:
                    RollbackAddOperation(operation, operation.Coins);
                    break;
                case StorageOperationType.RemoveCopperCoins:
                    operation.Storage!.CopperCoins += operation.Coins;
                    break;
                default:
                    throw new NotImplementedException();

            }
            operation.Executed = false;
        }

        private static void AddCoinsToDestinationFromSource(StorageOperation operation, decimal coins)
        {
            operation.Storage!.CopperCoins += coins;

            if (operation.SourceStorageId is not null)
                operation.StorageSource!.CopperCoins -= coins;
        }
        private static void RollbackAddOperation(StorageOperation operation, decimal coins)
        {
            operation.Storage!.CopperCoins -= coins;

            if (operation.SourceStorageId is not null)
                operation.StorageSource!.CopperCoins += coins;
        }
    }
}
