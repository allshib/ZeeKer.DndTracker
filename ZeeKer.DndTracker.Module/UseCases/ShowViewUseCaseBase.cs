using DevExpress.ExpressApp;
using DevExpress.Utils.CommonDialogs.Internal;
using DevExpress.Xpo;

namespace ZeeKer.DndTracker.Module.UseCases;

public abstract class ShowViewUseCaseBase
{
    protected readonly XafApplication application;


    protected ShowViewUseCaseBase(XafApplication application)
    {
        this.application = application;
    }


    protected DetailView CreateDetailView(IXafEntityObject entityObject, IObjectSpace objectSpace)
    {

        var detailView = application.CreateDetailView(objectSpace, entityObject);

        return detailView;
    }
    protected DetailView CreateDetailView(XPCustomObject entityObject, IObjectSpace objectSpace)
    {
        var detailView = application.CreateDetailView(objectSpace, entityObject);

        return detailView;
    }

    protected void OpenDetailView(DetailView detailView, Action okDelegate = null, Action cancelDelegate = null, string okCaption = null, string cancelCaption = null)
    {
        application.ShowViewStrategy.ShowViewInPopupWindow(detailView,
            okDelegate, cancelDelegate, okCaption, cancelCaption, null);
    }

    protected DialogResult OpenDetailViewWithDefaultSettings(DetailView detailView)
    {
        var result = DialogResult.None;

        OpenDetailView(detailView,
            () => result = DialogResult.OK, () => result = DialogResult.Cancel, "ОК", "Отмена");

        return result;
    }

    protected DialogResult CreateAndOpenDetailViewWithDefaultSettings(IXafEntityObject entityObject, IObjectSpace objectSpace)
    => OpenDetailViewWithDefaultSettings(CreateDetailView(entityObject, objectSpace));


}