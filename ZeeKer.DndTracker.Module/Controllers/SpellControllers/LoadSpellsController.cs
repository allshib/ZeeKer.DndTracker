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
using ZeeKer.DndTracker.Module.UseCases.LoadSpellsUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.SpellControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class LoadSpellsController : ViewController
    {
        private readonly ILoadSpellUseCase useCase;

        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public LoadSpellsController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Spell);
            TargetViewType = ViewType.ListView;

            var action = new SimpleAction(this, "LoadSpells", PredefinedCategory.Edit)
            {
                Caption = "Загрузить заклинания",
                ImageName = "Action_Load"
            };

            action.Execute += Action_Execute;
        }

        [ActivatorUtilitiesConstructor]
        public LoadSpellsController(ILoadSpellUseCase useCase) : this()
        {
            this.useCase = useCase;
        }

        private async void Action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            await useCase.Execute(new LoadSpellsCommand(ObjectSpace));

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
