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
using DevExpress.XtraSpreadsheet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;
using ZeeKer.DndTracker.Module.UseCases.SelectFeatUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.FeatsControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SelectFeatChangeViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public SelectFeatChangeViewController()
        {
            InitializeComponent();
            TargetObjectType = typeof(SelectFeatViewModel);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            var entity = View.CurrentObject as SelectFeatViewModel;
            entity.PropertyChanged += Entity_PropertyChanged;
        }

        private void Entity_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var entity = View.CurrentObject as SelectFeatViewModel;

            switch (e.PropertyName)
            {
                case nameof(SelectFeatViewModel.Feat) when entity.Feat is not null:
                    entity.StatSelectObjects.Clear();



                    if (entity.StatBonus is not null)
                    {
                        //entity.StatBonus.Reload();
                        //entity.StatBonus.GetObjectSpace().ReloadCollection(entity.GroupsList);

                        if (entity.StatBonus.BonusGroups.Count == 1)
                            entity.StattBonusGroup = entity.StatBonus.BonusGroups[0];
                        else
                            entity.StattBonusGroup = null;

                        View.RefreshDataSource();
                        //View.Refresh();
                    }
                    break;
                case nameof(SelectFeatViewModel.StattBonusGroup):
                    entity.StatSelectObjects.Clear();

                    if (entity.StattBonusGroup is not null)
                    {
                        foreach (var item in entity.StattBonusGroup.StatBonuses.Where(x => x.BonusType == Types.StatBonusType.Any))
                        {
                            entity.StatSelectObjects.Add(new StatSelectObject()
                            {
                                BonusType = Types.StatBonusType.Any,
                                Bonus = item.StatBonus,
                            });
                        }
                    }
                    View.RefreshDataSource();
                    //View.Refresh();
                    break;
            }
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
