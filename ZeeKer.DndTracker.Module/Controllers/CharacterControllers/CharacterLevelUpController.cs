using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.UseCases.LevelUpUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.CharacterControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CharacterLevelUpController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CharacterLevelUpController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Character);
            TargetViewType = ViewType.DetailView;

            var levelUpAction = new SimpleAction(this, "LevelUpAction", PredefinedCategory.Unspecified)
            {
                Caption = "Повысить уровень (ALPHA)"
            };
            levelUpAction.Execute += LevelUpAction_Execute;
        }

        private void LevelUpAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var useCase = new LevelUpUseCase(Application, View.CurrentObject as Character);

            useCase.LevelUp();
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
