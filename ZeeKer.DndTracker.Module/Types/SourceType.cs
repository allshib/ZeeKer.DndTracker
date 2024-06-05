using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Types
{
    public enum SourceType
    {
        [XafDisplayName("Не выбрано")]
        None = 0,
        [XafDisplayName("Книга игрока")]
        PHB = 1,
        [XafDisplayName("Руководство Занатара обо всем")]
        XGE = 2,
        [XafDisplayName("Котел Таши со всякой всячиной")]
        TCE = 3,
        [XafDisplayName("Сокровищница драконов Фицбана")]
        FTD = 4,
        [XafDisplayName("Книга многих вещей")]
        BMT = 5,
        [XafDisplayName("Homebrew")]
        HB = 401,
        [XafDisplayName("Laserllama")]
        LH = 402,
        [XafDisplayName("Путеводитель игрока: Прорастающий хаос")]
        PG = 403

    }
}
