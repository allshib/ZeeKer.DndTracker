﻿using DevExpress.ExpressApp;
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
                case StorageOperationType.AddItems when operation.OperationMode == OperationMode.WithAnotherStorage:
                    if (operation.Item.Count > operation.Coins)
                    {
                        operation.Item.Count -= Convert.ToInt32(operation.Coins);
                        var item = operation.Storage.Items.FirstOrDefault(item => item.ItemId == operation.ItemId);
                        if (item is not null)
                            item.Count += Convert.ToInt32(operation.Coins);
                        else
                        {
                            var assignedItem = operation.GetObjectSpace().CreateObject<AssignedItem>();
                            assignedItem.Item = operation.Item.Item;
                            assignedItem.Count = Convert.ToInt32(operation.Coins);
                            assignedItem.Storage = operation.Storage;
                        }
                    }
                    else if (operation.Item.Count == operation.Coins)
                    {
                        operation.Item.Storage = null;
                        operation.Item.SettingOnThis = false;
                        var item = operation.Storage.Items.FirstOrDefault(item => item.ItemId == operation.ItemId);
                        if (item is not null)
                            item.Count += Convert.ToInt32(operation.Coins);
                        else
                        {
                            operation.Item.Storage = operation.Storage;
                        }

                    }
                    else
                        throw new UserFriendlyException("Пошел нахуй");
                    break;
                    case StorageOperationType.AddItems when operation.OperationMode == OperationMode.Default:
                    var destinItem = operation.Storage.Items
                        .FirstOrDefault(x => x.ItemId == operation.SelectedItem.ID);
                    if(destinItem is null)
                    {
                        destinItem = operation.GetObjectSpace().CreateObject<AssignedItem>();
                        destinItem.Item = operation.SelectedItem;
                        destinItem.Storage = operation.Storage;
                        destinItem.Count = Convert.ToInt32(operation.Coins);
                    }
                    else
                    {
                        destinItem.Count += Convert.ToInt32(operation.Coins);
                    }
                    
                    operation.Item = destinItem;

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
            if(operation.OperationType == StorageOperationType.RemoveItems)
            {
                throw new UserFriendlyException("Пока не умею откатывать операции с предметами");
            }
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

                case StorageOperationType.AddItems when operation.OperationMode == OperationMode.WithAnotherStorage:
                    //TODO
                    var item = operation.Storage.Items.FirstOrDefault(item => item.ItemId == operation.ItemId);
                    if (item.Count > operation.Coins)
                    {
                        item.Count -= Convert.ToInt32(operation.Coins);


                        operation.Item.Count += Convert.ToInt32(operation.Coins);

                        operation.Item.Storage = operation.StorageSource;
                    }
                    else if (item.Count == operation.Coins)
                    {
                        item.Storage = null;

                        var sourceItem = operation.StorageSource.Items
                            .FirstOrDefault(item => item.ItemId == operation.ItemId);

                        if (sourceItem is not null)
                        {
                            sourceItem.Count += Convert.ToInt32(operation.Coins);
                        }
                        else
                        {
                            item.Storage = operation.StorageSource;
                        }

                    }
                    break;
                case StorageOperationType.AddItems when operation.OperationMode == OperationMode.Default:
                    var destinItem = operation.Storage.Items
                        .FirstOrDefault(x => x.ItemId == operation.SelectedItem.ID);
                    
                    if (destinItem.Count == operation.Coins)
                        destinItem.Storage = null;

                    destinItem.Count -= Convert.ToInt32(operation.Coins);

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
