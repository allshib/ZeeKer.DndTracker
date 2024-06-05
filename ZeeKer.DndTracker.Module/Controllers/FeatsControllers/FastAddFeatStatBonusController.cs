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
using ZeeKer.DndTracker.Module.UseCases.FastAddFeatStatBonusUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.FeatsControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FastAddFeatStatBonusController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public FastAddFeatStatBonusController()
        {
            InitializeComponent();
            TargetObjectType = typeof(FastAddFeatBonusViewModel);
            TargetViewType = ViewType.DetailView;
            var fastadd = new SimpleAction(this, "FastAddFeatStatBonusAction", ActionCategories.FastAddBonusStat)
            {
                Caption = "Добавить"
            };
            fastadd.Execute += Fastadd_Execute;


            var fastRemove = new SimpleAction(this, "FastRemoveFeatStatBonusAction", ActionCategories.FastAddBonusStat)
            {
                Caption = "Удалить"
            };
            fastRemove.Execute += FastRemove_Execute;
        }

        private void FastRemove_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var entity = View.CurrentObject as FastAddFeatBonusViewModel;
            var feat = entity.Feat;
            var os = feat.GetObjectSpace();

            var statBonus = feat.Bonuses
                .FirstOrDefault(x => x.Bonus.Type == BonusType.Stat).Bonus as StatBonus;

            if (statBonus is null)
                throw new UserFriendlyException("Такой бонус не найден");

            var group = entity.Group?? statBonus.BonusGroups
                .FirstOrDefault(x=>x.StatBonuses
                .Any(s => s.BonusType == entity.StatBonusType && s.StatBonus == entity.Value));
            
            if (group is null)
                throw new UserFriendlyException("Такой бонус не найден");

            if (group.StatBonuses.Count == 1)
                group.Delete();
            else
            {
               var bonus = group.StatBonuses
                    .FirstOrDefault(x => x.BonusType == entity.StatBonusType && x.StatBonus == entity.Value);
                if (bonus is not null)
                    bonus.Delete();
                else throw new UserFriendlyException("Такой бонус не найден");
            }



            os.CommitChanges();
            View.RefreshDataSource();
        }

        private void Fastadd_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var entity = View.CurrentObject as FastAddFeatBonusViewModel;

            if (entity.Value == 0)
                throw new UserFriendlyException("Нельзя добавлять нулевые бонусы");


            var feat = entity.Feat;
            var os = feat.GetObjectSpace();

            StatBonus statBonus = null;
            if (feat.Bonuses.Any(x => x.Bonus.Type == BonusType.Stat) == false)
            {
                var aBonus = os.CreateObject<AssignedFeatBonus>();
                aBonus.Feat = feat;
                statBonus = os.CreateObject<StatBonus>();
                aBonus.Bonus = statBonus;
            }
            else
            {
                statBonus = feat.Bonuses.First(x => x.Bonus.Type == BonusType.Stat).Bonus as StatBonus;
            }

            var group = entity.Group?? os.CreateObject<StatBonusGroup>();
            group.Bonus = statBonus;

            


            var oneStatBonus = group.StatBonuses
                .FirstOrDefault(x=>x.BonusType == entity.StatBonusType);

            if (oneStatBonus is null)
            {
                oneStatBonus = os.CreateObject<OneStatBonus>();
                oneStatBonus.Group = group;
                oneStatBonus.BonusType = entity.StatBonusType;
                oneStatBonus.StatBonus = entity.Value;
            }
            else
                oneStatBonus.StatBonus += entity.Value;

            

            os.CommitChanges();
            View.RefreshDataSource();
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
