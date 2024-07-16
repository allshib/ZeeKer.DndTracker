using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase
{
    #region Base Classes

    /// <summary>
    /// Базовый класс команды для перевода
    /// </summary>
    public abstract record TransferCommandBase
    {

        public GeneralTransferInfo General { get; init; }

        public OperationMode Mode { get; init; }

        public TransferCommandBase(GeneralTransferInfo general)
        {
            General = general;

        }
    }

    /// <summary>
    /// Простая команда
    /// </summary>
    public abstract record TransferStandartCommand : TransferCommandBase
    {
        public Guid? StorageDestinationId { get; init; }
        public TransferStandartCommand(GeneralTransferInfo general, Guid? storageDestinationId) : base(general)
        {
            StorageDestinationId = storageDestinationId;
            Mode = OperationMode.Default;
        }



    }
    /// <summary>
    /// Команда для превода между хранилищами
    /// </summary>
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
}
