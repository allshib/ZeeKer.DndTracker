using DevExpress.ExpressApp;
using Zeeker.DndTracker.Tests.Mock;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;
using ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

namespace Zeeker.DndTracker.Tests
{
    public class TransferUseCaseShould : TestBase
    {
        Character lina;
        Character alex;

        TransferUseCase useCase;

        public TransferUseCaseShould() : base()
        {
            useCase = new TransferUseCase(Application);

            lina = ObjectSpace.CreateObject<Character>();
            lina.Name = "Lina";

            alex = ObjectSpace.CreateObject<Character>();
            alex.Name = "Alex";

            var add100CommandForLina = CreateTransferMoneyStandartCommandForLina(100, StorageOperationType.AddGoldCoins);
            var add100CommandForAlex = CreateTransferMoneyStandartCommandForAlex(100, StorageOperationType.AddGoldCoins);
            useCase.Execute(add100CommandForLina, ObjectSpace);
            useCase.Execute(add100CommandForAlex, ObjectSpace);
            ObjectSpace.CommitChanges();

            
        }


        [Fact]
        public void Add10GoldToStorage()
        {
            var add10Command = CreateTransferMoneyStandartCommandForLina(10, StorageOperationType.AddGoldCoins);

            useCase.Execute(add10Command, ObjectSpace);

            
            Assert.Equal(110, lina.LocalStorage.GoldCoins);
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op=>op.Coins == 10 && op.OperationType == StorageOperationType.AddGoldCoins).Count());
            Assert.Equal(0, lina.LocalStorage.OperationsFromThis?.Count());
        }

        [Fact]
        public void Remove10GoldFromStorage()
        {
            var remove10Command = CreateTransferMoneyStandartCommandForLina(10, StorageOperationType.RemoveGoldCoins);

            useCase.Execute(remove10Command, ObjectSpace);

            
            Assert.Equal(90, lina.LocalStorage.GoldCoins);
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 100 && op.OperationType == StorageOperationType.AddGoldCoins).Count());
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 10 && op.OperationType == StorageOperationType.RemoveGoldCoins).Count());
            Assert.Equal(0, lina.LocalStorage.OperationsFromThis?.Count());
        }


        [Fact]
        public void Remove1SilverCoinFromStorage()
        {
            var remove1Command = CreateTransferMoneyStandartCommandForLina(1, StorageOperationType.RemoveSilverCoins);

            useCase.Execute(remove1Command, ObjectSpace);


            Assert.Equal(99.9m, lina.LocalStorage.GoldCoins);
            Assert.Equal(999, lina.LocalStorage.SilverCoins);
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 100 && op.OperationType == StorageOperationType.AddGoldCoins).Count());
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 1 && op.OperationType == StorageOperationType.RemoveSilverCoins).Count());
            Assert.Equal(0, lina.LocalStorage.OperationsFromThis?.Count());
        }


        [Fact]
        public void Add1SilverCoinToStorage()
        { 
            var add1SilverCommand = CreateTransferMoneyStandartCommandForLina(1, StorageOperationType.AddSilverCoins);
            
            useCase.Execute(add1SilverCommand, ObjectSpace);


            Assert.Equal(100.1m, lina.LocalStorage.GoldCoins);
            Assert.Equal(1001, lina.LocalStorage.SilverCoins);
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 100 && op.OperationType == StorageOperationType.AddGoldCoins).Count());
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 1 && op.OperationType == StorageOperationType.AddSilverCoins).Count());
            Assert.Equal(0, lina.LocalStorage.OperationsFromThis?.Count());
        }

        [Fact]
        public void Add1CoperCoinToStorage()
        {
            var add1CopperCommand = CreateTransferMoneyStandartCommandForLina(1, StorageOperationType.AddCopperCoins);

            useCase.Execute(add1CopperCommand, ObjectSpace);


            Assert.Equal(1000.1m, lina.LocalStorage.SilverCoins);
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 100 && op.OperationType == StorageOperationType.AddGoldCoins).Count());
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 1 && op.OperationType == StorageOperationType.AddCopperCoins).Count());
            Assert.Equal(0, lina.LocalStorage.OperationsFromThis?.Count());
        }

        [Fact]
        public void Remove1CoperCoinFromStorage()
        {
            var remove1CopperCommand = CreateTransferMoneyStandartCommandForLina(1, StorageOperationType.RemoveCopperCoins);

            useCase.Execute(remove1CopperCommand, ObjectSpace);


            Assert.Equal(999.9m, lina.LocalStorage.SilverCoins);
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 100 && op.OperationType == StorageOperationType.AddGoldCoins).Count());
            Assert.Equal(1, lina.LocalStorage.Operations?.Where(op => op.Coins == 1 && op.OperationType == StorageOperationType.RemoveCopperCoins).Count());
            Assert.Equal(0, lina.LocalStorage.OperationsFromThis?.Count());
        }


        private TransferMoneyStandartCommand CreateTransferMoneyStandartCommandForLina(int count, StorageOperationType operationType)
        {
            var general = new GeneralTransferInfo(count, operationType, lina.CampainId);
            return new TransferMoneyStandartCommand(general, lina.LocalStorage.ID, true);
        }

        private TransferMoneyStandartCommand CreateTransferMoneyStandartCommandForAlex(int count, StorageOperationType operationType)
        {
            var general = new GeneralTransferInfo(count, operationType, lina.CampainId);
            return new TransferMoneyStandartCommand(general, alex.LocalStorage.ID, true);
        }
    }
}