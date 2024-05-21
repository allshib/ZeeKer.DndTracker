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

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

public class ManageCoinsUseCase : ShowViewUseCaseBase
{
    public ManageCoinsUseCase(XafApplication application) : base(application)
    {
    }
    public delegate void AfterCommitEventHandler(object? sender, AfterCommitEventArgs e);

    public event AfterCommitEventHandler AfterCommit;
    public void Execute(ManageCoinsCommand request)
    {
        var os = application
            .CreateObjectSpace(typeof(StorageOperation));

        var operation = os.CreateObject<StorageOperation>();
        operation.StorageId = request.StorageDestinationId;
        operation.OperationType = request.Type;
        operation.Coins = request.Coins;
        operation.OperationMode = request.Mode;
        operation.SourceStorageId = request.StorageSourceId;
        operation.CampainId = request.CampainId;

        operation.DestinationCharacter = request.DestinationCharacterId is not null
            ? os.GetObjectByKey<Character>(request.DestinationCharacterId)
            : operation.Storage?.Character;

        operation.SourceCharacter = request.SourceCharacterId is not null
            ? os.GetObjectByKey<Character>(request.SourceCharacterId)
            : operation.StorageSource?.Character;


        if (request.FastOperation)
            RunOperation(operation, os, request.FastOperation);
        else
        {
            var detailView = this.CreateDetailView(operation, os);
            this.OpenDetailView(detailView, () =>
            {
                if (
                operation.Coins >= 1 && 
                operation.Storage is not null && 
                operation.StorageSource is not null && 
                operation.StorageId != operation.SourceStorageId)
                    RunOperation(operation, os, request.FastOperation);
                else
                    throw new UserFriendlyException("Не все поля заданы");

                
            });
        }
        

    }

    private void RunOperation(StorageOperation operation, IObjectSpace os, bool fastOperation)
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
                operation.RollbackOperation();

            if (fastOperation)
                throw;
        }
        AfterCommit?.Invoke(this, new AfterCommitEventArgs());
    }

    public record AfterCommitEventArgs();
}