using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.ItemParser;

namespace ZeeKer.DndTracker.DndSu.Entities
{
    public record SimpleItemCard(string Name, string FullLink): IItemLink;
}
