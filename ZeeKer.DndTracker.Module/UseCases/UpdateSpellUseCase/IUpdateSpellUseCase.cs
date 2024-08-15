using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.UseCases.UpdateSpellUseCase
{
    public interface IUpdateSpellUseCase
    {

        public Task Execute(UpdateSpellCommand request);
    }
}
