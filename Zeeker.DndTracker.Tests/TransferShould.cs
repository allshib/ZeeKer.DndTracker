using Zeeker.DndTracker.Tests.Mock;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;
using ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

namespace Zeeker.DndTracker.Tests
{
    public class TransferShould : TestBase
    {
        Character lina;

        TransferUseCase useCase;

        public TransferShould() : base()
        {
            lina = ObjectSpace.CreateObject<Character>();
            lina.Name = "Lina";

            ObjectSpace.CommitChanges();

            useCase = new TransferUseCase(Application);
        }


        [Fact]
        public void SimpleAdd10GoldToStorage()
        {
            var general = new GeneralTransferInfo(10, StorageOperationType.AddGoldCoins, lina.CampainId);

            useCase.Execute(new TransferMoneyStandartCommand(general, lina.LocalStorage.ID, true));


            Assert.Equal(10, lina.LocalStorage.GoldCoins);
        }
    }
}