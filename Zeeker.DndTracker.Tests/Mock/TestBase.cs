using DevExpress.ExpressApp;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeeker.DndTracker.Tests.Mock
{
    public class TestBase
    {
        protected MockCreateSimpleCommand mock;

        protected IObjectSpace ObjectSpace => mock.ObjectSpace;

        protected XafApplication Application => MockCreateSimpleCommand.Application;

        public TestBase()
        {
            mock = new MockCreateSimpleCommand();
        }
    }
}
