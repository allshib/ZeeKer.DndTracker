using DevExpress.ExpressApp;
using System.Security.AccessControl;
using DevExpress.EntityFrameworkCore.Security;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;
using static System.Net.Mime.MediaTypeNames;
using ZeeKer.DndTracker.Module.Controllers;

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
        operation.StorageId = request.StorageId;
        operation.OperationType = request.Type;
        operation.Coins = request.Coins;



        var detailView = this.CreateDetailView(operation, os);
        this.OpenDetailView(detailView, () =>
        {
            
            switch (operation.OperationType)
            {
                case StorageOperationType.AddGoldCoins:
                    operation.Storage!.СopperСoins += operation.Coins * 100;
                    break;
                case StorageOperationType.RemoveGoldCoins:
                    operation.Storage!.СopperСoins -= operation.Coins * 100;
                    break;
                case StorageOperationType.AddSilverCoins:
                    operation.Storage!.СopperСoins += operation.Coins * 10;
                    break;
                case StorageOperationType.RemoveSilverCoins:
                    operation.Storage!.СopperСoins -= operation.Coins * 10;
                    break;
                case StorageOperationType.AddCopperCoins:
                    operation.Storage!.СopperСoins += operation.Coins;
                    break;
                case StorageOperationType.RemoveCopperCoins:
                    operation.Storage!.СopperСoins -= operation.Coins;
                    break;
                default:
                    throw new NotImplementedException();

            }
            os.CommitChanges();
            AfterCommit?.Invoke(this, new AfterCommitEventArgs());
            
        });

    }

    public record AfterCommitEventArgs();
}