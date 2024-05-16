using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.LongStoryShort.Dtos;
// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
public class DisabledBlocks
{
    [JsonPropertyName("info-left")]
    public List<object> infoleft { get; set; }

    [JsonPropertyName("info-right")]
    public List<object> inforight { get; set; }

    [JsonPropertyName("notes-left")]
    public List<object> notesleft { get; set; }

    [JsonPropertyName("notes-right")]
    public List<object> notesright { get; set; }
    public string _id { get; set; }
}

public class LongStoryShortData
{
    public List<object> tags { get; set; }
    public Spells spells { get; set; }
    public string data { get; set; }
    public string jsonType { get; set; }
    public string version { get; set; }
    public DisabledBlocks disabledBlocks { get; set; }
}

public class Spells
{
    public string mode { get; set; }
    public List<string> prepared { get; set; }
    public List<object> book { get; set; }
}

