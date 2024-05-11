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

            var addGold100Gold = new SimpleAction(this, "Add100Gold", ActionCategories.AddGoldCategory)
            {
                Caption = "+100з"
            };
            addGold100Gold.Execute += AddGold100Gold_Execute;



            var removeGold1Gold = new SimpleAction(this, "RemoveRemoveGold", ActionCategories.RemoveGoldCategory)
            {
                Caption = "-1з"
            };
            removeGold1Gold.Execute += RemoveGold1Gold_Execute;


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
        }

        private void RemoveGold100Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
            => ExecuteSimpleOperation(1, StorageOperationType.RemoveGoldCoins);
        private void RemoveGold10Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
            => ExecuteSimpleOperation(10, StorageOperationType.RemoveGoldCoins);
        private void RemoveGold1Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
            => ExecuteSimpleOperation(100, StorageOperationType.RemoveGoldCoins);




        private void AddGold100Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
            => ExecuteSimpleOperation(100, StorageOperationType.AddGoldCoins);
        private void AddGold10Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
            => ExecuteSimpleOperation(10, StorageOperationType.AddGoldCoins);
        private void AddGold1Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        => ExecuteSimpleOperation(1, StorageOperationType.AddGoldCoins);
        


        private void ExecuteSimpleOperation(decimal coins, StorageOperationType type)
        => useCase
            .Execute(
                new ManageCoinsCommand(
                    ((Character)View.CurrentObject).LocalStorage.ID, coins, type));

        private void UseCase_AfterCommit(object sender, ManageCoinsUseCase.AfterCommitEventArgs e)
        {
            ObjectSpace.ReloadObject(((Character)View.CurrentObject).LocalStorage);
            ObjectSpace.ReloadCollection(((Character)View.CurrentObject).LocalStorage.Operations);
        }

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
            if(useCase is not null)
                useCase.AfterCommit -= UseCase_AfterCommit;

            base.OnDeactivated();
        }
    }
}
