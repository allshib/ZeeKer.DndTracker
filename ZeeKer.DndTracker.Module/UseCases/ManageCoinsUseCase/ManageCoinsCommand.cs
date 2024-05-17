using DevExpress.ExpressApp;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

public record ManageCoinsCommand(
    Guid? CampainId,
    Guid? StorageDestinationId,
    decimal Coins, 
    StorageOperationType Type, 
    OperationMode Mode = OperationMode.Default, 
    Guid? StorageSourceId = null,
    Guid? SourceCharacterId = null,
    Guid? DestinationCharacterId = null,
    bool FastOperation = false);