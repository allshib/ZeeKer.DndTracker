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
using ZeeKer.DndTracker.Module.UseCases.CloneCharacterUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.CharacterControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CreateDefaultClassCharacterController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CreateDefaultClassCharacterController()
        {
            InitializeComponent();
            TargetObjectType = typeof(CharacterClass);
            var action = new SimpleAction(this, "CreateDefaultClassCharacter", PredefinedCategory.Edit)
            {
                Caption = "Создать персонажа"
            };

            action.Execute += Action_Execute;
        }

        private void Action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var cloner = new CloneCharacterUseCase(Application);
            var cclass = View.CurrentObject as CharacterClass;
            //cloner.Execute(new CloneCharacterCommand(cclass.DefaultCharacter));
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
