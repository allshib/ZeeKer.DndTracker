using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;
using ZeeKer.DndTracker.Module.Types;
using ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;
using static ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase.TransferCommandBase;
using static ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase.TransferSendCommand;

namespace ZeeKer.DndTracker.Module.Controllers.TransferSystemControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TransferCoinsController : ViewController
    {
        private TransferUseCase useCase;

        private Character Character => View.CurrentObject as Character;
        public TransferCoinsController()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Character);

            #region InitActions
            this.CreateSimpleAction("AddOneGold", "+1з",  ActionCategories.AddGoldCategory, AddGold1Gold_Execute);
            this.CreateSimpleAction("AddTenGold", "+10з",  ActionCategories.AddGoldCategory, AddGold10Gold_Execute);
            this.CreateSimpleAction("Add50Gold", "+50з", ActionCategories.AddGoldCategory, AddGold50Gold_Execute);
            this.CreateSimpleAction("Add100Gold", "+100з", ActionCategories.AddGoldCategory, AddGold100Gold_Execute);
            this.CreateSimpleAction("Add250Gold", "+250з", ActionCategories.AddGoldCategory, AddGold250Gold_Execute);
            this.CreateSimpleAction("Add500Gold", "+500з", ActionCategories.AddGoldCategory, AddGold500Gold_Execute);

            this.CreateSimpleAction("Remove1Gold", "-1з",  ActionCategories.RemoveGoldCategory, RemoveGold1Gold_Execute);
            this.CreateSimpleAction("Remove2Gold", "-2з", ActionCategories.RemoveGoldCategory, RemoveGold2Gold_Execute);
            this.CreateSimpleAction("Remove3Gold", "-3з", ActionCategories.RemoveGoldCategory, RemoveGold3Gold_Execute);
            this.CreateSimpleAction("Remove5Gold", "-5з", ActionCategories.RemoveGoldCategory, RemoveGold5Gold_Execute);
            this.CreateSimpleAction("RemoveTenGold", "-10з", ActionCategories.RemoveGoldCategory, RemoveGold10Gold_Execute);
            this.CreateSimpleAction("Remove100Gold", "-100з", ActionCategories.RemoveGoldCategory, RemoveGold100Gold_Execute);
            this.CreateSimpleAction("Remove250Gold", "-250з", ActionCategories.RemoveGoldCategory, RemoveGold250Gold_Execute);
            this.CreateSimpleAction("Remove500Gold", "-500з", ActionCategories.RemoveGoldCategory, RemoveGold500Gold_Execute);

            this.CreateSimpleAction("SimpleTransferGold", "Между своими", ActionCategories.SendGoldCategory, SimpleTransferGold_Execute);
            this.CreateSimpleAction("SendGold", "Отправить", ActionCategories.SendGoldCategory, SendGold_Execute);
            #endregion
        }



        #region Events
        protected override void OnActivated()
        {
            base.OnActivated();

            useCase = new TransferUseCase(Application);
            useCase.AfterCommit += UseCase_AfterCommit;

        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            if (useCase is not null)
                useCase.AfterCommit -= UseCase_AfterCommit;

            base.OnDeactivated();
        }

        private void UseCase_AfterCommit(object sender, TransferUseCase.AfterCommitEventArgs e)
        {
            ObjectSpace.ReloadObject(((Character)View.CurrentObject).LocalStorage);
            ObjectSpace.ReloadCollection(((Character)View.CurrentObject).LocalStorage.Operations);
            ObjectSpace.ReloadCollection(((Character)View.CurrentObject).Storages);
        }
        #endregion


        #region Methods

        

        private void ExecuteSimpleMoneyOperation(Guid? campainId, decimal coins, StorageOperationType type, bool fastOperation = false)
        {
            var general = new GeneralTransferInfo(coins, type, campainId);

            useCase.Execute(
                    new TransferMoneyStandartCommand(general, Character.LocalStorage.ID, fastOperation));
        }


        #endregion


        /// <summary>
        /// Отправить голду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendGold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var general = new GeneralTransferInfo(0, StorageOperationType.AddGoldCoins, Character.CampainId);
            var storagesInfo = new TransferStoragesInfo( 
                StorageSourceId: Character!.LocalStorage.ID,
                SourceCharacterId: Character.ID);

            var command = new TransferMoneySendCommand(general, storagesInfo);

            useCase.Execute(command);
        }

        /// <summary>
        /// Перевод голды себе в инвентарь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleTransferGold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var general = new GeneralTransferInfo(0, StorageOperationType.AddGoldCoins, Character.CampainId);
            var storagesInfo = new TransferStoragesInfo(
                StorageDestinationId: Character.LocalStorage.ID,
                DestinationCharacterId: Character.ID,
                SourceCharacterId: Character.ID);


            var command = new TransferMoneySendCommand(general, storagesInfo);

            useCase.Execute(command);
        }

        #region RemoveCoins
        private void RemoveGold100Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 100,
                StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void RemoveGold10Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 10,
                StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void RemoveGold1Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 1,
                StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void RemoveGold3Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 3, StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void RemoveGold2Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 2, StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void RemoveGold5Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 5, StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void RemoveGold500Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 500, StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void RemoveGold250Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 250, StorageOperationType.RemoveGoldCoins, Character.LocalStorage.FastOperations);
        }
        #endregion

        #region AddCoins
        private void AddGold100Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 100, StorageOperationType.AddGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void AddGold10Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 10, StorageOperationType.AddGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void AddGold1Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 1, StorageOperationType.AddGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void AddGold500Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 500, StorageOperationType.AddGoldCoins, Character.LocalStorage.FastOperations);
        }

        private void AddGold250Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 250, StorageOperationType.AddGoldCoins, Character.LocalStorage.FastOperations);
        }
        private void AddGold50Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ExecuteSimpleMoneyOperation(Character.CampainId, 50, StorageOperationType.AddGoldCoins, Character.LocalStorage.FastOperations);
        }
        #endregion
    }
}
