using DevExpress.ExpressApp;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

public record ManageCoinsCommand(Guid StorageId,decimal Coins, StorageOperationType Type);