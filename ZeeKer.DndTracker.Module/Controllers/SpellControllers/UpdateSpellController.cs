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
using ZeeKer.DndTracker.Module.UseCases.UpdateSpellUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.SpellControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class UpdateSpellController : ViewController
    {
        private readonly IUpdateSpellUseCase useCase;

        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public UpdateSpellController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Spell);
            TargetViewType = ViewType.DetailView;

            var action = new SimpleAction(this, "UpdateSpell", PredefinedCategory.Edit)
            {
                Caption = "Обновить заклинание",
                ImageName = "Action_Edit"
            };

            action.Execute += Action_Execute;
        }

        [ActivatorUtilitiesConstructor]
        public UpdateSpellController(IUpdateSpellUseCase useCase) : this()
        {
            this.useCase = useCase;
        }

        private async void Action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            await useCase.Execute(new UpdateSpellCommand(View.CurrentObject as Spell));
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
