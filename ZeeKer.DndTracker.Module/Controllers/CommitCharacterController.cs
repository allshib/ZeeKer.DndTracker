//using DevExpress.Data.Filtering;
//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Actions;
//using DevExpress.ExpressApp.Editors;
//using DevExpress.ExpressApp.Layout;
//using DevExpress.ExpressApp.Model.NodeGenerators;
//using DevExpress.ExpressApp.SystemModule;
//using DevExpress.ExpressApp.Templates;
//using DevExpress.ExpressApp.Utils;
//using DevExpress.Persistent.Base;
//using DevExpress.Persistent.Validation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using ZeeKer.DndTracker.Module.BusinessObjects;
//using ZeeKer.DndTracker.Module.Extensions;

//namespace ZeeKer.DndTracker.Module.Controllers
//{
//    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
//    public partial class CommitCharacterController : ViewController
//    {
//        // Use CodeRush to create Controllers and Actions with a few keystrokes.
//        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
//        public CommitCharacterController()
//        {
//            InitializeComponent();
//            TargetObjectType = typeof(Character);
//        }

//        private bool executed=false;
//        protected override void OnActivated()
//        {
//            base.OnActivated();
//            if (ObjectSpace.IsNewObject(View.CurrentObject))
//            {
//                ObjectSpace.Committed += ObjectSpace_Committed;
//            }
//        }

//        private void ObjectSpace_Committed(object sender, EventArgs e)
//        {
//            if (executed)
//            {
//                ObjectSpace.Committed -= ObjectSpace_Committed;
//                return;
//            }


//            var character = View.CurrentObject as Character;

//            if (character.Stats.CharacterId is null)
//            {
//                character.Fix();
//                executed = true;
//                try
//                {
//                    ObjectSpace.CommitChanges();
//                }
//                catch
//                {
//                    executed = false;
//                    throw;
//                }
//            }

//        }

//        protected override void OnViewControlsCreated()
//        {
//            base.OnViewControlsCreated();
//            // Access and customize the target View control.
//        }
//        protected override void OnDeactivated()
//        {
//            base.OnDeactivated();
//        }
//    }
//}
