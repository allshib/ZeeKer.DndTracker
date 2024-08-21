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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.UseCases.LoadItemsUseCase;
using ZeeKer.DndTracker.Module.UseCases.LoadSpellsUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.ItemsControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class LoadItemsController : ViewController
    {
        private readonly ILoadItemsUseCase useCase;

        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public LoadItemsController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Item);
            TargetViewType = ViewType.ListView;

            var action = new SimpleAction(this, "LoadItems", PredefinedCategory.Edit)
            {
                Caption = "Загрузить предметы"
            };

            action.Execute += Action_Execute;
        }

        [ActivatorUtilitiesConstructor]
        public LoadItemsController(ILoadItemsUseCase useCase) : this()
        {
            this.useCase = useCase;
        }

        private async void Action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            await useCase.Execute(new LoadItemsCommand(ObjectSpace));

            ObjectSpace.CommitChanges();

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
