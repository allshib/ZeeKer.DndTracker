using DevExpress.ExpressApp.DC;

namespace ZeeKer.DndTracker.Module.Types;

public enum DiceRollType
{
    [XafDisplayName("Неизвестно")]
    Unknown = 0,
    K20 = 20,
    K12 = 12,
    K10 = 10,
    K8 = 8,
    K6 = 6,
    K4 = 4,
}