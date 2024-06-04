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
            CreateSimpleAction("AddOneGold", "+1з",  ActionCategories.AddGoldCategory, AddGold1Gold_Execute);
            CreateSimpleAction("AddTenGold", "+10з",  ActionCategories.AddGoldCategory, AddGold10Gold_Execute);
            CreateSimpleAction("Add50Gold", "+50з", ActionCategories.AddGoldCategory, AddGold50Gold_Execute);
            CreateSimpleAction("Add100Gold", "+100з", ActionCategories.AddGoldCategory, AddGold100Gold_Execute);
            CreateSimpleAction("Add250Gold", "+250з", ActionCategories.AddGoldCategory, AddGold250Gold_Execute);
            CreateSimpleAction("Add500Gold", "+500з", ActionCategories.AddGoldCategory, AddGold500Gold_Execute);

            CreateSimpleAction("Remove1Gold", "-1з",  ActionCategories.RemoveGoldCategory, RemoveGold1Gold_Execute);
            CreateSimpleAction("Remove2Gold", "-2з", ActionCategories.RemoveGoldCategory, RemoveGold2Gold_Execute);
            CreateSimpleAction("Remove3Gold", "-3з", ActionCategories.RemoveGoldCategory, RemoveGold3Gold_Execute);
            CreateSimpleAction("Remove5Gold", "-5з", ActionCategories.RemoveGoldCategory, RemoveGold5Gold_Execute);
            CreateSimpleAction("RemoveTenGold", "-10з", ActionCategories.RemoveGoldCategory, RemoveGold10Gold_Execute);
            CreateSimpleAction("Remove100Gold", "-100з", ActionCategories.RemoveGoldCategory, RemoveGold100Gold_Execute);
            CreateSimpleAction("Remove250Gold", "-250з", ActionCategories.RemoveGoldCategory, RemoveGold250Gold_Execute);
            CreateSimpleAction("Remove500Gold", "-500з", ActionCategories.RemoveGoldCategory, RemoveGold500Gold_Execute);

            CreateSimpleAction("SimpleTransferGold", "Между своими", ActionCategories.SimpleTransferGoldCategory, SimpleTransferGold_Execute);
            CreateSimpleAction("SendGold", "Отправить", ActionCategories.SimpleTransferGoldCategory, SendGold_Execute);
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

        private SimpleAction CreateSimpleAction(string id, string caption, string category, SimpleActionExecuteEventHandler handler)
        {
            var action = new SimpleAction(this, id, category)
            {
                Caption = caption
            };
            action.Execute += handler;
            return action;
        }

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
