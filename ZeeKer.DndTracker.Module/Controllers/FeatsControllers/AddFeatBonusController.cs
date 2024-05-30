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
using ZeeKer.DndTracker.Module.UseCases;

namespace ZeeKer.DndTracker.Module.Controllers.FeatsControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class AddFeatBonusController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public AddFeatBonusController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Feat);
            TargetViewType = ViewType.DetailView;

            var addFeatBonusAction = new SingleChoiceAction(this, "AddFeatBonusAction", PredefinedCategory.Unspecified)
            {
                Caption = "Добавить бонус"
            };
            addFeatBonusAction.Items.Add(new ChoiceActionItem("Бонус характеристик", BonusType.Stat));

            addFeatBonusAction.Execute += AddFeatBonusAction_Execute;
        }
        
        private void AddFeatBonusAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            if (e.SelectedChoiceActionItem is null)
                return;

            switch((BonusType)e.SelectedChoiceActionItem.Data)
            {
                case BonusType.Stat:
                    var useCase = new ShowBonusViewUseCase(Application);
                    var nested = ObjectSpace.CreateNestedObjectSpace();
                    useCase.Show(nested, () =>
                    {
                        var aBonus = ObjectSpace.CreateObject<AssignedFeatBonus>();
                        aBonus.Feat = View.CurrentObject as Feat;

                        nested.CommitChanges();

                        aBonus.Bonus = ObjectSpace.GetObject(useCase.Bonus);
                    });
                    break;
            }
        }

        public class ShowBonusViewUseCase : ShowViewUseCaseBase
        {
            public ShowBonusViewUseCase(XafApplication application) : base(application)
            {
            }
            public StatBonus Bonus { get; set; }
            public void Show(IObjectSpace os, Action okAction)
            {

                var bonus = os.CreateObject<StatBonus>();
                Bonus = bonus;
                var detailView = CreateDetailView(bonus, os);

                this.OpenDetailView(detailView, okAction);
                
            }
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
