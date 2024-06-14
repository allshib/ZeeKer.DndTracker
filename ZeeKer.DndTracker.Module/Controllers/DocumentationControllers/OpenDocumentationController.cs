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
using ZeeKer.DndTracker.Module.UseCases.OpenDocumentationUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.DocumentationControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class OpenDocumentationController : ViewController
    {
        private SimpleAction openDoc;
        private CriteriaOperator criteria;
        public OpenDocumentationController()
        {
            InitializeComponent();
            TargetObjectType = typeof(IOpenDoc);
            TargetViewType = ViewType.DetailView;

            openDoc = new SimpleAction(this, "OpenDocAction", PredefinedCategory.Unspecified)
            {
                Caption = "Открыть документацию"
            };
            openDoc.Execute += OpenDoc_Execute;

        }

        private void OpenDoc_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var doc = ObjectSpace.FindObject<DocumentationInfo>(criteria);

            doc.HyperLink?.HyperLink.OpenAsLink();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            var typeName = View.CurrentObject.GetType().BaseType.FullName;
            criteria = CriteriaOperator.Parse("ObjectTypeName = ? And Active = True", typeName);

            if (ObjectSpace.Exists<DocumentationInfo>(criteria))
            {
                openDoc.Active["Block"] = true;
            }
            else
            {
                openDoc.Active["Block"] = false;
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
