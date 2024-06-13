using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
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

namespace ZeeKer.DndTracker.Module.Controllers.HyperLinkControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class HyperLinkController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public HyperLinkController()
        {
            InitializeComponent();
            TargetObjectType = typeof(HyperlinkObject);
            TargetViewType = ViewType.ListView;
        }
        ListView ListView => View is not null? View as ListView: null;
        protected override void OnActivated()
        {
            base.OnActivated();
            
            
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            //switch (ListView.Editor)
            //{
            //    case DxGridListEditor dxGrid:
            //        dxGrid.RowClickMode = RowClickMode.ProcessOnDouble;
                    
            //        var gridAdapter = dxGrid.GetGridAdapter();
            //        foreach (var t in gridAdapter.GridDataColumnModels.ToList())
            //        {
            //            t.
            //        }
            //        //var gridColumns = gridAdapter.GridDataColumnModels;

            //        //foreach ( var column in gridColumns )
            //        //{
            //        //    column.
            //        //}


            //        break;
            //}
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
