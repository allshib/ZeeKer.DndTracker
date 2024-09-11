using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Mappers;

namespace ZeeKer.DndTracker.Module.UseCases.CloneCharacterUseCase
{
    public class CloneCharacterUseCase : ShowViewUseCaseBase, ICloneCharacterUseCase
    {
        public CloneCharacterUseCase(XafApplication application) : base(application)
        {
        }

        public void Execute(CloneCharacterCommand command)
        {
            var os = application.CreateObjectSpace(typeof(Character));

            var newCharacter = os.CreateObject<Character>();
            
            command.Character.CustomMapTo(newCharacter, command.withLocalStorage);

            var dv = application.CreateDetailView(os, newCharacter);


            OpenDetailView(dv);

        }
    }
}
