using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeeker.DndTracker.Tests.Mock
{
    public class TestApplication : XafApplication
    {
        protected override LayoutManager CreateLayoutManagerCore(bool simple)
        {
            return null;
        }

        protected override void OnDatabaseVersionMismatch(DatabaseVersionMismatchEventArgs e)
        {
            base.OnDatabaseVersionMismatch(e);
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
