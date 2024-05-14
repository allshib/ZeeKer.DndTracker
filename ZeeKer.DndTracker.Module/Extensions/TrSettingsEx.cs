using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Extensions
{
    internal static class TrSettingsEx
    {

        public static decimal GetCopperCoinsSum(this TransactionSettings transaction)
        {
            switch(transaction.OperationType)
            {
                case Types.StorageOperationType.AddGoldCoins:
                    return transaction.Coins*100;
                case Types.StorageOperationType.AddSilverCoins:
                    return transaction.Coins*10;
                case Types.StorageOperationType.AddCopperCoins:
                    return transaction.Coins;
                default:
                    return 0;
            }
        }
    }
}
