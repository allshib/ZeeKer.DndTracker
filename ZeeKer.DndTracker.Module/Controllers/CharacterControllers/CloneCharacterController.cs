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
using ZeeKer.DndTracker.Module.UseCases.CloneCharacterUseCase;
using ZeeKer.DndTracker.Module.UseCases.LoadItemsUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.CharacterControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CloneCharacterController : ViewController
    {
        
        public CloneCharacterController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Character);


            var action = new SimpleAction(this, "CloneCharacterWithItems", PredefinedCategory.Edit)
            {
                Caption = "Клонировать персонажа с предметами",
            };

            action.Execute += Action_Execute;

            var action1 = new SimpleAction(this, "CloneCharacter", PredefinedCategory.Edit)
            {
                Caption = "Клонировать персонажа",
            };

            action1.Execute += Action_Execute1;

        }

        private void Action_Execute1(object sender, SimpleActionExecuteEventArgs e)
        {
            var cloner = new CloneCharacterUseCase(Application);


            cloner.Execute(new CloneCharacterCommand((Character)View.CurrentObject));
        }

        private void Action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var cloner = new CloneCharacterUseCase(Application);


            cloner.Execute(new CloneCharacterCommand((Character)View.CurrentObject, true));
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
