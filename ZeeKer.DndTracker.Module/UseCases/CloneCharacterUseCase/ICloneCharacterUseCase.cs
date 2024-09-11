using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.UseCases.CloneCharacterUseCase
{
    public interface ICloneCharacterUseCase
    {

        public void Execute(CloneCharacterCommand command);
    }
}
