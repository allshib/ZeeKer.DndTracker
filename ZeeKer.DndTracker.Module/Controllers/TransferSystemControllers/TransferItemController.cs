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
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;
using ZeeKer.DndTracker.Module.Types;
using ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;
using static ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase.TransferCommandBase;
using static ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase.TransferSendCommand;

namespace ZeeKer.DndTracker.Module.Controllers.TransferSystemControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TransferItemController : ViewController
    {
        private TransferUseCase useCase;

        private Character Character => View.CurrentObject as Character;
        public TransferItemController()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Character);

            this.CreateSimpleAction("GetItem", "Получить предмет", ActionCategories.TransferItemsCategory, GetItem_Execute);
            this.CreateSimpleAction("SimpleTransferItem", "Между своими (предмет)", ActionCategories.TransferItemsCategory, SimpleTransferItem_Execute);
            this.CreateSimpleAction("SendItem", "Отправить предмет", ActionCategories.TransferItemsCategory, SendItem_Execute);

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


        private void GetItem_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            var general = new GeneralTransferInfo(1, StorageOperationType.AddItems, Character.CampainId);

            var command = new TransferItemStandartCommand(general, Character.LocalStorage.ID);

            useCase.Execute(command);
        }

        private void SimpleTransferItem_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var general = new GeneralTransferInfo(1, StorageOperationType.AddItems, Character.CampainId);
            var storagesInfo = new TransferStoragesInfo(
                StorageSourceId: Character!.LocalStorage.ID,
                SourceCharacterId: Character.ID,
                StorageDestinationId: Character!.LocalStorage.ID,
                DestinationCharacterId: Character.ID);

            var command = new TransferItemSendCommand(general, storagesInfo);

            useCase.Execute(command);
        }

        private void SendItem_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var general = new GeneralTransferInfo(1, StorageOperationType.AddItems, Character.CampainId);
            var storagesInfo = new TransferStoragesInfo(
                StorageSourceId: Character!.LocalStorage.ID,
                SourceCharacterId: Character.ID);

            var command = new TransferItemSendCommand(general,storagesInfo);

            useCase.Execute(command);
        }
    }
}
