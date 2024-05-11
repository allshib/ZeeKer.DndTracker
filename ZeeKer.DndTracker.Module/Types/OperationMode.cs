using DevExpress.ExpressApp.DC;

namespace ZeeKer.DndTracker.Module.Types;

public enum OperationMode
{
    [XafDisplayName("Стандартный")]
    Default,
    [XafDisplayName("Между хранилищами")]
    WithAnotherStorage
}