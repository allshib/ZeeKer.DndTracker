using DevExpress.ExpressApp.DC;

namespace ZeeKer.DndTracker.Module.Types;

public enum StorageOperationType
{
    [XafDisplayName("Добавить золотые монеты")]
    AddGoldCoins,
    [XafDisplayName("Отнять золотые монеты")]
    RemoveGoldCoins,
    [XafDisplayName("Добавить серебрянные монеты")]
    AddSilverCoins,
    [XafDisplayName("Отнять серебрянные монеты")]
    RemoveSilverCoins,
    [XafDisplayName("Добавить медные монеты")]
    AddCopperCoins,
    [XafDisplayName("Отнять золотые монеты")]
    RemoveCopperCoins,
    [XafDisplayName("Добавить предметы")]
    AddItems,
    [XafDisplayName("Отнять предметы")]
    RemoveItems,
}