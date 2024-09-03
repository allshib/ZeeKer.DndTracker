using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.UseCases.CreateWeaponUseCase
{
    public interface ICreateWeaponUseCase
    {

        void Execute(CreateWeaponCommand command);
    }
}
