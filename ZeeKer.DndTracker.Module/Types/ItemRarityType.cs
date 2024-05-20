using DevExpress.ExpressApp.DC;

namespace ZeeKer.DndTracker.Module.Types;

public enum ItemRarityType
{
    [XafDisplayName("Неизвестно")]
    Unknown,
    [XafDisplayName("Обычный")]
    Common,

    [XafDisplayName("Необычный")]
    Uncommon,

    [XafDisplayName("Редкий")]
    Rare,

    [XafDisplayName("Очень редкий")]
    VeryRare,

    [XafDisplayName("Легендарный")]
    Legendary
    ,
    [XafDisplayName("Артефакт")]
    Artifact
}