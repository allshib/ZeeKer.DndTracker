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
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SwapStoragesController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public SwapStoragesController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(StorageOperation);
            TargetViewType = ViewType.DetailView;

            var swapAction = new SimpleAction(this, "SwapStorages", ActionCategories.SwapStoragesCategory)
            {
                Caption = "Поменять"
            };
            swapAction.Execute += SwapAction_Execute;
        }

        private void SwapAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var operation = View.CurrentObject as StorageOperation;
            var source = operation.StorageSource;
            var sourceCharacter = operation.SourceCharacter;
            var destination = operation.Storage;
            var destinationCharacter = operation.DestinationCharacter;

            operation.DestinationCharacter = sourceCharacter;
            operation.SourceCharacter = destinationCharacter;

            operation.StorageSource = destination;
            operation.Storage = source;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
