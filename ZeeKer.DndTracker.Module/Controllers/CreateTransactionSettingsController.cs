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
using ZeeKer.DndTracker.Module.Types;
using ZeeKer.DndTracker.Module.UseCases;

namespace ZeeKer.DndTracker.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CreateTransactionSettingsController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CreateTransactionSettingsController()
        {
            InitializeComponent();
            TargetObjectType = typeof(MultipleTransaction);
            TargetViewType = ViewType.DetailView;
            var createTransactionSettings = new SimpleAction(this, "CreateTransaction", ActionCategories.CreateTransactionCategory)
            {
                Caption = "Создать настройку"
            };
            createTransactionSettings.Execute += CreateTransactionSettings_Execute;

        }

        private void CreateTransactionSettings_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var useCase = new TransactionCreateUseCase(Application);
            var multiple = View.CurrentObject as MultipleTransaction;
            useCase.Execute(multiple.ID);
            useCase.AfterCommit += UseCase_AfterCommit;


        }

        private void UseCase_AfterCommit(object sender, EventArgs args)
        {
            var multiple = View.CurrentObject as MultipleTransaction;
            ObjectSpace.ReloadCollection(multiple.TransactionSettings);
        }

        public class TransactionCreateUseCase : ShowViewUseCaseBase
        {
            public TransactionCreateUseCase(XafApplication application) : base(application)
            {
            }

            public delegate void AfterCommitHandler(object sender, EventArgs args);
            public event AfterCommitHandler AfterCommit;
            public void Execute(Guid multipleTr)
            {
                var os = application.CreateObjectSpace(typeof(TransactionSettings));

                var trSettings = os.CreateObject<TransactionSettings>();
                trSettings.Transaction = os.GetObjectByKey<MultipleTransaction>(multipleTr);

                var detailView = this.CreateDetailView(trSettings, os);

                this.OpenDetailView(detailView,
                    () =>
                    {
                        os.CommitChanges();
                        AfterCommit?.Invoke(this, EventArgs.Empty);
                    });
                    

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
