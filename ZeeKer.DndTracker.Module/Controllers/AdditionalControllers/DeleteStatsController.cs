using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Controllers.AdditionalControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DeleteStatsController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public DeleteStatsController()
        {
            InitializeComponent();
            TargetObjectType = typeof(CharacterStats);
            TargetViewType = ViewType.ListView;
            var deleteOldStats = new SimpleAction(this, "DeleteOldStats", PredefinedCategory.Unspecified)
            {
                Caption = "Удалить старые объекты"
            };
            deleteOldStats.Execute += DeleteOldStats_Execute;
        }

        private void DeleteOldStats_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var stats = ObjectSpace.GetObjects<CharacterStats>(CriteriaOperator.Parse($"{nameof(CharacterStats.CharacterId)} = ?", null));

            foreach(var item in stats)
            {
                if (ObjectSpace.FindObject<Character>(CriteriaOperator.Parse($"{nameof(Character.StatsId)} = ?", item.ID)) is null)
                {
                    ObjectSpace.Delete(item);
                }
            }
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
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
