using DevExpress.ExpressApp;
using DevExpress.ExpressApp.EFCore;
using DevExpress.ExpressApp.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace Zeeker.DndTracker.Tests.Mock
{
    public class TestApplication : XafApplication
    {
        private readonly EFCoreObjectSpaceProvider<DndTrackerEFCoreDbContext> osProvider;

        protected override LayoutManager CreateLayoutManagerCore(bool simple)
        {
            return null;
        }

        public TestApplication(EFCoreObjectSpaceProvider<DndTrackerEFCoreDbContext> osProvider)
        {
            this.osProvider = osProvider;
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            base.CreateDefaultObjectSpaceProvider(args);

            args.ObjectSpaceProviders.Add(osProvider);
        }

        protected override void OnDatabaseVersionMismatch(DatabaseVersionMismatchEventArgs e)
        {
            base.OnDatabaseVersionMismatch(e);
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
