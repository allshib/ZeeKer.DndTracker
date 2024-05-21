using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.EntityFrameworkCore.Security;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;
using ZeeKer.DndTracker.Module.UseCases;
using ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ZeeKer.DndTracker.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ManageCoinsController : ViewController
    {
        private ManageCoinsUseCase useCase;
        public ManageCoinsController()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Character);

            #region InitActions
            var addGold1Gold = new SimpleAction(this, "AddOneGold", ActionCategories.AddGoldCategory)
            {
                Caption = "+1з"
            };
            addGold1Gold.Execute += AddGold1Gold_Execute;


            var addGold10Gold = new SimpleAction(this, "AddTenGold", ActionCategories.AddGoldCategory)
            {
                Caption = "+10з"
            };
            addGold10Gold.Execute += AddGold10Gold_Execute;

            var addGold50Gold = new SimpleAction(this, "Add50Gold", ActionCategories.AddGoldCategory)
            {
                Caption = "+50з"
            };
            addGold50Gold.Execute += AddGold50Gold_Execute;

            var addGold100Gold = new SimpleAction(this, "Add100Gold", ActionCategories.AddGoldCategory)
            {
                Caption = "+100з"
            };
            addGold100Gold.Execute += AddGold100Gold_Execute;

            var addGold250Gold = new SimpleAction(this, "Add250Gold", ActionCategories.AddGoldCategory)
            {
                Caption = "+250з"
            };
            addGold250Gold.Execute += AddGold250Gold_Execute;

            var addGold500Gold = new SimpleAction(this, "Add500Gold", ActionCategories.AddGoldCategory)
            {
                Caption = "+500з"
            };
            addGold500Gold.Execute += AddGold500Gold_Execute;



            var removeGold1Gold = new SimpleAction(this, "Remove1Gold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-1з"
            };
            removeGold1Gold.Execute += RemoveGold1Gold_Execute;

            var removeGold2Gold = new SimpleAction(this, "Remove2Gold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-2з"
            };
            removeGold2Gold.Execute += RemoveGold2Gold_Execute;

            var removeGold3Gold = new SimpleAction(this, "Remove3Gold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-3з"
            };
            removeGold3Gold.Execute += RemoveGold3Gold_Execute;

            var removeGold5Gold = new SimpleAction(this, "Remove5Gold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-5з"
            };
            removeGold5Gold.Execute += RemoveGold5Gold_Execute;

            var removeGold10Gold = new SimpleAction(this, "RemoveTenGold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-10з"
            };
            removeGold10Gold.Execute += RemoveGold10Gold_Execute;

            var removeGold100Gold = new SimpleAction(this, "Remove100Gold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-100з"
            };
            removeGold100Gold.Execute += RemoveGold100Gold_Execute;

            var removeGold250Gold = new SimpleAction(this, "Remove250Gold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-250з"
            };
            removeGold250Gold.Execute += RemoveGold250Gold_Execute;

            var removeGold500Gold = new SimpleAction(this, "Remove500Gold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-500з"
            };
            removeGold500Gold.Execute += RemoveGold500Gold_Execute;


            var simpleTransferGold = new SimpleAction(this, "SimpleTransferGold", ActionCategories.SimpleTransferGoldCategory)
            {
                Caption = "Между своими"
            };
            simpleTransferGold.Execute += SimpleTransferGold_Execute;

            var sendGold = new SimpleAction(this, "SendGold", ActionCategories.SimpleTransferGoldCategory)
            {
                Caption = "Отправить"
            };
            sendGold.Execute += SendGold_Execute;
            #endregion
        }
        #region Events
        protected override void OnActivated()
        {
            base.OnActivated();

            useCase = new ManageCoinsUseCase(Application);
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

        private void UseCase_AfterCommit(object sender, ManageCoinsUseCase.AfterCommitEventArgs e)
        {
            ObjectSpace.ReloadObject(((Character)View.CurrentObject).LocalStorage);
            ObjectSpace.ReloadCollection(((Character)View.CurrentObject).LocalStorage.Operations);
            ObjectSpace.ReloadCollection(((Character)View.CurrentObject).Storages);
        }
        #endregion


        #region Methods
        private void ExecuteSimpleOperation(Guid? campainId, decimal coins, StorageOperationType type, bool fastOperation = false)
        => useCase
            .Execute(
                new ManageCoinsCommand(campainId,
                    ((Character)View.CurrentObject).LocalStorage.ID, coins, type, FastOperation: fastOperation));


        private void ExecuteOperation(
            Guid? campainId,
            Guid? destinationStorageId,
            decimal coins,
            StorageOperationType type,
            OperationMode mode = OperationMode.Default,
            Guid? sourceStorageId = null,
            Guid? sourceCharacterId = null,
            Guid? destinationCharacterId = null)
            => useCase
                .Execute(
                    new ManageCoinsCommand(campainId,
                        destinationStorageId, coins, type, mode, sourceStorageId, sourceCharacterId, destinationCharacterId));

        #endregion


        /// <summary>
        /// Отправить голду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendGold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteOperation(character.CampainId,
                null,
                0,
                StorageOperationType.AddGoldCoins,
                OperationMode.WithAnotherStorage,
                character!.LocalStorage.ID,
                character.ID,
                null);
        }

        /// <summary>
        /// Перевод голды себе в инвентарь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleTransferGold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            var character = View.CurrentObject as Character;
            ExecuteOperation(
                character.CampainId,
                character.LocalStorage.ID,
                0,
                StorageOperationType.AddGoldCoins,
                OperationMode.WithAnotherStorage,
                null,
                character.ID,
                character.ID);
        }

        #region RemoveCoins
        private void RemoveGold100Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 100,
                StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }

        private void RemoveGold10Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 10,
                StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }

        private void RemoveGold1Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 1,
                StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }

        private void RemoveGold3Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 3, StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }

        private void RemoveGold2Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 2, StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }

        private void RemoveGold5Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 5, StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }

        private void RemoveGold500Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 500, StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }

        private void RemoveGold250Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 250, StorageOperationType.RemoveGoldCoins, character.LocalStorage.FastOperations);
        }
        #endregion

        #region AddCoins
        private void AddGold100Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 100, StorageOperationType.AddGoldCoins, character.LocalStorage.FastOperations);
        }

        private void AddGold10Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 10, StorageOperationType.AddGoldCoins, character.LocalStorage.FastOperations);
        }

        private void AddGold1Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 1, StorageOperationType.AddGoldCoins, character.LocalStorage.FastOperations);
        }

        private void AddGold500Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 500, StorageOperationType.AddGoldCoins, character.LocalStorage.FastOperations);
        }

        private void AddGold250Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 250, StorageOperationType.AddGoldCoins, character.LocalStorage.FastOperations);
        }
        private void AddGold50Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var character = View.CurrentObject as Character;
            ExecuteSimpleOperation(character.CampainId, 50, StorageOperationType.AddGoldCoins, character.LocalStorage.FastOperations);
        }
        #endregion
    }
}
