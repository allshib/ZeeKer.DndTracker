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
        public ManageCoinsController()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Character);
            var addGold1Gold = new SimpleAction(this, "AddOneGold", PredefinedCategory.Unspecified)
            {
                Caption = "+1з"
            };
            addGold1Gold.Execute += AddGold1Gold_Execute;

        }

        private ManageCoinsUseCase useCase;

        private void AddGold1Gold_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            useCase
                .Execute(
                    new ManageCoinsCommand(
                        ((Character)View.CurrentObject).LocalStorage.ID, 
                        1, 
                        StorageOperationType.AddGoldCoins));
        }

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
