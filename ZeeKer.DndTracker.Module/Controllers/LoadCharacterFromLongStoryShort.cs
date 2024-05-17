using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeeKer.DndTracker.LongStoryShort.Services;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent;
using ZeeKer.DndTracker.Module.UseCases.SelectCharactersUseCase;

namespace ZeeKer.DndTracker.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class LoadCharacterFromLongStoryShort : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public LoadCharacterFromLongStoryShort()
        {
            InitializeComponent();
            TargetObjectType = typeof(Character);
            TargetViewType = ViewType.ListView;
            var importFromLLS = new PopupWindowShowAction(this, "ImportFromLongStoryShort", PredefinedCategory.Unspecified)
            {
                Caption = "Импорт из LSS (ALFA)"
            };
            importFromLLS.Execute += LoadFromLLS_Execute;
            importFromLLS.CustomizePopupWindowParams += LoadFromLLS_CustomizePopupWindowParams;
        }

        private void LoadFromLLS_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var json = GetJson(((UploadFileParameters)e.PopupWindowViewCurrentObject).File);
            var facade = new LongStoryFacade();
            var characterList = facade
                .GetDataList(json)
                .Select(facade.GetCharacterData)
                .ToList();

            var useCase = new SelectAndLoadCharacterUseCase(Application);

            useCase.ShowDialog(characterList, ObjectSpace);
        }

        private void LoadFromLLS_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(UploadFileParameters));
            os.PopulateAdditionalObjectSpaces(Application);
            e.DialogController.SaveOnAccept = false;
            e.View = e.Application.CreateDetailView(os, os.CreateObject<UploadFileParameters>());
        }


        private string GetJson(FileData file)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.SaveToStream(stream);
                    stream.Position = 0;

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch {
                throw new UserFriendlyException("Что-то пошло не так");
            }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
