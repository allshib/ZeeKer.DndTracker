using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZeeKer.DndTracker.LongStoryShort.Dtos;

namespace ZeeKer.DndTracker.LongStoryShort.Services
{
    public class GetCharacterDataService
    {



        public CharacterData GetCharacterData(LongStoryShortData longStory) {
        
            var result = longStory.data.Replace("\\", "");

            return JsonSerializer.Deserialize<CharacterData>(result)!;
        }
    }
}
