using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.UseCases.GetDndSuLinkBySpellNameUseCase
{
    public interface IGetDndSuLinkBySpellNameUseCase
    {
        public Task Execute(GetDndSuLinkBySpellNameCommand request);
    }
}
