using DevExpress.EntityFrameworkCore.Security;
using DevExpress.ExpressApp;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.ExecuteMultipleTransactionUseCase
{
    internal class ExecuteMultipleTransactionUseCase(IObjectSpace objectSpace)
    {


        public void Execute(MultipleTransaction transaction)
        {
            if (transaction is null || transaction.TransactionSettings is null || transaction.TransactionSettings.Count < 1)
                throw new ArgumentException("Некорректная транзакция");

            try
            {
                ExecuteTransaction(transaction);
                objectSpace.CommitChanges();
            }
            catch (Exception ex)
            {
                objectSpace.Rollback();
                throw new UserFriendlyException("Транзакция не прошла");
            }

        }

        private void ExecuteTransaction(MultipleTransaction transaction)
        {
            foreach (var settings in transaction.TransactionSettings)
            {
                var storageOperation = objectSpace.CreateObject<StorageOperation>();
                storageOperation.Reason = transaction.Reason;
                storageOperation.OperationType = settings.OperationType;
                storageOperation.StorageSource = transaction.StorageSource;
                storageOperation.Storage = settings.StorageDestination;
                storageOperation.Coins = settings.Coins;
                storageOperation.MultipleTransaction = transaction;

                storageOperation.ExecuteOperation();
            }
        }
    }
}
