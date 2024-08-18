using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Contracts.Parsers.ItemParser;

public interface IItemLink
{
    string Name { get; }
    string FullLink { get; }
}

