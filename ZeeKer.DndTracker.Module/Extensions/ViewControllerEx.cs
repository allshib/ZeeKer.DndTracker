using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace ZeeKer.DndTracker.Module.Extensions;

public static class ViewControllerEx
{

    public static SimpleAction CreateSimpleAction(this ViewController controller, string id, string caption, string category, SimpleActionExecuteEventHandler handler)
    {
        var action = new SimpleAction(controller, id, category)
        {
            Caption = caption
        };
        action.Execute += handler;
        return action;
    }

}