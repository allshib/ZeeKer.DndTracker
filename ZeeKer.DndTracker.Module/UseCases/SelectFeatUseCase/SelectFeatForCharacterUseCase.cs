using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.SelectFeatUseCase
{
    internal class SelectFeatForCharacterUseCase : ShowViewUseCaseBase
    {
        public SelectFeatForCharacterUseCase(XafApplication application) : base(application)
        {
        }



        public void Execute(Character character)
        {
            var characterObjectSpace = character.GetObjectSpace();
            var entity = new SelectFeatViewModel(characterObjectSpace.GetObjects<Feat>());
            var os = application.CreateObjectSpace(typeof(SelectFeatViewModel));
            var dv = CreateDetailView(entity, os);

            this.OpenDetailView(dv, () => {
                var feat = characterObjectSpace.CreateObject<AvailableFeat>();
                feat.Name = entity.Feat.Name;
                feat.Description = entity.Feat.Description;
                feat.FeatId = entity.Feat.ID;
                feat.Character = character;
                feat.LevelAdded = character.Level;
                characterObjectSpace.CommitChanges();
            });

        }
    }
}
