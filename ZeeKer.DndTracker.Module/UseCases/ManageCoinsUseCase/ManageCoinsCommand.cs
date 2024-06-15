using DevExpress.ExpressApp;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;




#region Base Classes
public abstract record TransferCommandBase {

    public GeneralTransferInfo General { get; init; }

    public OperationMode Mode { get; init; }

    public TransferCommandBase(GeneralTransferInfo general)
    {
        General = general;
    }
}


public abstract record TransferStandartCommand : TransferCommandBase
{
    public Guid? StorageDestinationId { get; init; }
    public TransferStandartCommand(GeneralTransferInfo general, Guid? storageDestinationId) : base(general)
    {
        StorageDestinationId = storageDestinationId;
        Mode = OperationMode.Default;
    }


    
}

public abstract record TransferSendCommand : TransferCommandBase
{
    
    public TransferStoragesInfo StoragesInfo { get; init; }

    public TransferSendCommand(GeneralTransferInfo general, TransferStoragesInfo storagesInfo) : base(general)
    {
        Mode = OperationMode.WithAnotherStorage;
        StoragesInfo = storagesInfo;
    }



}
#region AdditionalRecords
public record GeneralTransferInfo(decimal Count, StorageOperationType Type, Guid? CampainId);
public record TransferStoragesInfo(
    Guid? StorageDestinationId = null,
    Guid? DestinationCharacterId = null,
    Guid? StorageSourceId = null,
    Guid? SourceCharacterId = null);
#endregion

#endregion



public record TransferMoneyStandartCommand : TransferStandartCommand
{
    public bool FastOperation = false;

    public TransferMoneyStandartCommand(GeneralTransferInfo general, Guid? storageDestinationId, bool fastOperation) 
        : base(general, storageDestinationId)
    {
        FastOperation = fastOperation;
    }

}

public record TransferItemStandartCommand : TransferStandartCommand
{


    public TransferItemStandartCommand(GeneralTransferInfo general, Guid? storageDestinationId)
        : base(general, storageDestinationId)
    {

    }
}


public record TransferMoneySendCommand : TransferSendCommand
{

    public TransferMoneySendCommand(GeneralTransferInfo general, TransferStoragesInfo storagesInfo) : base(general, storagesInfo)
    {
        
    }

}

public record TransferItemSendCommand : TransferSendCommand
{

    public TransferItemSendCommand(GeneralTransferInfo general, TransferStoragesInfo storagesInfo) : base(general, storagesInfo)
    {

    }

}




