using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent;

namespace ZeeKer.DndTracker.Module.UseCases.SelectCharactersUseCase
{
    internal class SelectAndLoadCharacterUseCase : ShowViewUseCaseBase
    {
        public SelectAndLoadCharacterUseCase(XafApplication application) : base(application)
        {
        }


        public void ShowDialog(List<CharacterData> characters)
        {
            var entity = new CharacterDataList(characters);
            var os = application.CreateObjectSpace(typeof(CharacterDataList));
            var dv = this.CreateDetailView(entity, os);

            this.OpenDetailView(dv, () =>
            {
                var selectedChatacters = entity.CharacterDataItems.Where(ch => ch.Selected).ToList();
            });
        }
    }
}
