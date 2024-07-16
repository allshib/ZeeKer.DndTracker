using DevExpress.ExpressApp;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

/// <summary>
/// Простая команда для перевода монет
/// </summary>
public record TransferMoneyStandartCommand : TransferStandartCommand
{
    public bool FastOperation { get; init; }

    public TransferMoneyStandartCommand(GeneralTransferInfo general, Guid? storageDestinationId, bool fastOperation = false) 
        : base(general, storageDestinationId)
    {
        FastOperation = fastOperation;
    }

}


/// <summary>
/// Простая команда для перевода предметов
/// </summary>
public record TransferItemStandartCommand : TransferStandartCommand
{


    public TransferItemStandartCommand(GeneralTransferInfo general, Guid? storageDestinationId)
        : base(general, storageDestinationId)
    {

    }
}

/// <summary>
/// Команда для перевода денег с одного хранилища в другое
/// </summary>
public record TransferMoneySendCommand : TransferSendCommand
{

    public TransferMoneySendCommand(GeneralTransferInfo general, TransferStoragesInfo storagesInfo) : base(general, storagesInfo)
    {
        
    }

}


/// <summary>
/// Команда для перевода предметов с одного хранилища в другое
/// </summary>
public record TransferItemSendCommand : TransferSendCommand
{

    public TransferItemSendCommand(GeneralTransferInfo general, TransferStoragesInfo storagesInfo) : base(general, storagesInfo)
    {

    }

}




