using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZeeKer.DndTracker.LongStoryShort.Dtos;

namespace ZeeKer.DndTracker.LongStoryShort.Services
{
    public class GetLongStoryDataService
    {


        public List<LongStoryShortData> GetLongStoryShortData(string data)
        {
            var result = JsonSerializer.Deserialize<List<LongStoryShortData>>(data);


            return result;
        }
    }
}
