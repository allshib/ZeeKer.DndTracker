using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.LevelUpUseCase
{
    internal class LevelUpUseCase
    {
        private readonly XafApplication application;
        private readonly Character character;
        private readonly IObjectSpace objectSpace;

        public LevelUpUseCase(XafApplication application, Character character)
        {
            this.application = application;
            this.character = character;
            objectSpace = character.GetObjectSpace();
        }


        public void LevelUp()
        {
            character.Level++;

            if(character.Class is not null)
            {
                character.HealthMax += ((int)character.Class.HealthDice / 2) + 1 + character.Stats.ConstitutionBonus;
            }
        }

    }
}
