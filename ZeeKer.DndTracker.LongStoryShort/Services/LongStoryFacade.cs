using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.LongStoryShort.Dtos;

namespace ZeeKer.DndTracker.LongStoryShort.Services
{
    public class LongStoryFacade
    {
        private readonly GetCharacterDataService getCharacterDataService = new GetCharacterDataService();
        private readonly GetLongStoryDataService getLongStoryDataService  = new GetLongStoryDataService();


        public List<LongStoryShortData> GetDataList(string jsonWithList)
        {
            return getLongStoryDataService.GetLongStoryShortData(jsonWithList);
        }


        public CharacterData GetCharacterData(LongStoryShortData longStoryShortData)
        {
            return getCharacterDataService.GetCharacterData(longStoryShortData);
        }
    }
}
