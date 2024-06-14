using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum HyperlinkCategoryType
    {
        [XafDisplayName("Обычная")]
        Simple,
        [XafDisplayName("Mind Map")]
        MindMap,
    }
}
