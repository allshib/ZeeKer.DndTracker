using DevExpress.ExpressApp;
using System.Security.AccessControl;
using DevExpress.EntityFrameworkCore.Security;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;
using static System.Net.Mime.MediaTypeNames;
using ZeeKer.DndTracker.Module.Controllers;
using Azure;
using Microsoft.Identity.Client.Extensions.Msal;
using ZeeKer.DndTracker.Module.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

public class TransferUseCase : ShowViewUseCaseBase
{
    public TransferUseCase(XafApplication application) : base(application)
    {
    }
    public delegate void AfterCommitEventHandler(object? sender, AfterCommitEventArgs e);

    public event AfterCommitEventHandler AfterCommit;
    public void Execute(TransferCommandBase request)
    {
        var os = application
            .CreateObjectSpace(typeof(StorageOperation));

        var operation = CreateAndFillOperation(request, os);

        var isFastOperation = request is TransferMoneyStandartCommand standartCommand? standartCommand.FastOperation : false;

        if (isFastOperation)
            RunOperation(operation, os);
        else
        {
            var detailView = this.CreateDetailView(operation, os);
            this.OpenDetailView(detailView, () =>
            {
                if (ValidateOperation(operation))
                    RunOperation(operation, os);
                else
                    throw new UserFriendlyException("Не все поля заданы");
            });
        }
        

    }

    private StorageOperation CreateAndFillOperation(TransferCommandBase request, IObjectSpace os)
    {
        var operation = os.CreateObject<StorageOperation>();

        operation.OperationType = request.General.Type;
        operation.Coins = request.General.Count;
        operation.OperationMode = request.Mode;
        operation.CampainId = request.General.CampainId;


        switch (request)
        {
            case TransferStandartCommand standartCommand:
                operation.StorageId = standartCommand.StorageDestinationId;
                
                break;
            case TransferSendCommand sendCommand:
                operation.StorageId = sendCommand.StoragesInfo.StorageDestinationId;
                operation.SourceStorageId = sendCommand.StoragesInfo.StorageSourceId;
                operation.DestinationCharacter = sendCommand.StoragesInfo.DestinationCharacterId is not null
                    ? os.GetObjectByKey<Character>(sendCommand.StoragesInfo.DestinationCharacterId)
                    : operation.Storage?.Character;

                operation.SourceCharacter = sendCommand.StoragesInfo.SourceCharacterId is not null
                    ? os.GetObjectByKey<Character>(sendCommand.StoragesInfo.SourceCharacterId)
                    : operation.StorageSource?.Character;

                break;
        }

        return operation;
    }

    private bool ValidateOperation(StorageOperation operation)
    => operation.Coins >= 1 &&
                operation.Storage is not null &&
                (operation.OperationMode == OperationMode.WithAnotherStorage && operation.StorageSource is not null 
        || operation.OperationMode != OperationMode.WithAnotherStorage) &&
                operation.StorageId != operation.SourceStorageId &&
                (operation.OperationType == StorageOperationType.AddItems
                && operation.Item is not null
                || operation.OperationType != StorageOperationType.AddItems ||
                operation.OperationType == StorageOperationType.AddItems && operation.SelectedItem is not null && operation.OperationMode == OperationMode.Default);

    private void RunOperation(StorageOperation operation, IObjectSpace os)
    {
        if (operation.Executed)
            operation.RollbackOperation();

        operation.ExecuteOperation();
        try
        {
            os.CommitChanges();
        }
        catch (Exception ex)
        {
            if (operation.Executed)
            {
                operation.RollbackOperation();
            }

            throw;
        }
        AfterCommit?.Invoke(this, new AfterCommitEventArgs());
    }

    public record AfterCommitEventArgs();
}