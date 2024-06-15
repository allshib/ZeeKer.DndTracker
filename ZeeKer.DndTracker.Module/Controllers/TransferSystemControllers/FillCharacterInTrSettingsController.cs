using DevExpress.ExpressApp;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Controllers.TransferSystemControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FillCharacterInTrSettingsController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public FillCharacterInTrSettingsController()
        {
            InitializeComponent();
            TargetObjectType = typeof(TransactionSettings);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
           var tr = View.CurrentObject as TransactionSettings;
            if(tr.StorageDestination?.Character is not null)
                tr.DestinationCharacter = tr.StorageDestination?.Character;
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
