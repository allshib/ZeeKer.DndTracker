using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.UseCases.CloneCharacterUseCase
{
    public record CloneCharacterCommand(Character Character, bool withLocalStorage = false);
}
