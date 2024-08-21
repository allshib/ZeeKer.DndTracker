using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.UseCases.LoadItemsUseCase
{
    public interface ILoadItemsUseCase
    {
        Task Execute(LoadItemsCommand request);
    }
}
