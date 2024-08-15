using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum LoadSpellResult
    {
        [XafDisplayName("Не загружено")]
        [ImageName("State_Validation_Information")]
        NotLoaded,
        [XafDisplayName("Успешно")]
        [ImageName("State_Validation_Valid")]
        LoadSuccess,
        [XafDisplayName("Неудача")]
        [ImageName("State_Validation_Invalid")]
        LoadFailed
    }
}
