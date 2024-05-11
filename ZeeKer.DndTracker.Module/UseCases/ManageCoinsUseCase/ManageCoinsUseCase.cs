using DevExpress.ExpressApp;
using System.Security.AccessControl;
using DevExpress.EntityFrameworkCore.Security;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;
using static System.Net.Mime.MediaTypeNames;
using ZeeKer.DndTracker.Module.Controllers;
using Azure;
using Microsoft.Identity.Client.Extensions.Msal;

namespace ZeeKer.DndTracker.Module.UseCases.ManageCoinsUseCase;

public class ManageCoinsUseCase: ShowViewUseCaseBase
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


        var detailView = this.CreateDetailView(operation, os);
        this.OpenDetailView(detailView, () =>
        {
            CalculateStorageCoins(operation);

            os.CommitChanges();
            AfterCommit?.Invoke(this, new AfterCommitEventArgs());
            
        });

    }

    private void CalculateStorageCoins(StorageOperation operation)
    {
        switch (operation.OperationType)
        {
            case StorageOperationType.AddGoldCoins:
                var addGoldCoins = operation.Coins * 100;

                operation.Storage!.СopperСoins += addGoldCoins;

                if (operation.SourceStorageId is not null)
                    operation.StorageSource!.СopperСoins -= addGoldCoins;
                break;
            case StorageOperationType.RemoveGoldCoins:
                operation.Storage!.СopperСoins -= operation.Coins * 100;
                break;
            case StorageOperationType.AddSilverCoins:
                var addSilverCoins = operation.Coins * 10;

                operation.Storage!.СopperСoins += addSilverCoins;

                if (operation.SourceStorageId is not null)
                    operation.StorageSource!.СopperСoins -= addSilverCoins;
                break;
            case StorageOperationType.RemoveSilverCoins:
                operation.Storage!.СopperСoins -= operation.Coins * 10;
                break;
            case StorageOperationType.AddCopperCoins:
                operation.Storage!.СopperСoins += operation.Coins;

                if (operation.SourceStorageId is not null)
                    operation.StorageSource!.СopperСoins -= operation.Coins;
                break;
            case StorageOperationType.RemoveCopperCoins:
                operation.Storage!.СopperСoins -= operation.Coins;
                break;
            default:
                throw new NotImplementedException();

        }
    }
    public record AfterCommitEventArgs();
}