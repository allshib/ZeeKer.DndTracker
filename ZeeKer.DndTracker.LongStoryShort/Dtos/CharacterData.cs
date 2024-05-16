// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Text.Json.Serialization;

public class Ac
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class Acrobatics
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Age
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Alignment
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class AnimalHandling
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Arcana
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Athletics
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Available
{
    [JsonPropertyName("classes")]
    public List<string> classes { get; set; }
}

public class Avatar
{
    [JsonPropertyName("jpeg")]
    public string jpeg { get; set; }

    [JsonPropertyName("webp")]
    public string webp { get; set; }
}

public class Background
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Base
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class BonusesSkills
{
}

public class BonusesStats
{
}

public class Cha
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("score")]
    public int score { get; set; }

    [JsonPropertyName("modifier")]
    public int modifier { get; set; }

    [JsonPropertyName("check")]
    public int check { get; set; }

    [JsonPropertyName("isProf")]
    public bool isProf { get; set; }
}

public class CharClass
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Coins
{
}

public class Con
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("score")]
    public int score { get; set; }

    [JsonPropertyName("modifier")]
    public int modifier { get; set; }

    [JsonPropertyName("check")]
    public int check { get; set; }

    [JsonPropertyName("isProf")]
    public bool isProf { get; set; }
}

public class Content
{
    [JsonPropertyName("type")]
    public string type { get; set; }
}

public class Data
{
    [JsonPropertyName("type")]
    public string type { get; set; }

    [JsonPropertyName("content")]
    public List<Content> content { get; set; }
}

public class Deception
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Dex
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("score")]
    public int score { get; set; }

    [JsonPropertyName("modifier")]
    public int modifier { get; set; }

    [JsonPropertyName("check")]
    public int check { get; set; }

    [JsonPropertyName("isProf")]
    public bool isProf { get; set; }
}

public class Dmg
{
    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Experience
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class Eyes
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Hair
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Height
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class History
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class HpCurrent
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class HpDiceCurrent
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class HpDiceMulti
{
}

public class HpMax
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class HpTemp
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class Ideals
{
    [JsonPropertyName("value")]
    public Value value { get; set; }

    [JsonPropertyName("isHidden")]
    public bool isHidden { get; set; }
}

public class Info
{
    [JsonPropertyName("charClass")]
    public CharClass charClass { get; set; }

    [JsonPropertyName("level")]
    public Level level { get; set; }

    [JsonPropertyName("background")]
    public Background background { get; set; }

    [JsonPropertyName("playerName")]
    public PlayerName playerName { get; set; }

    [JsonPropertyName("race")]
    public Race race { get; set; }

    [JsonPropertyName("alignment")]
    public Alignment alignment { get; set; }

    //[JsonPropertyName("experience")]
    //public Experience experience { get; set; }
}

public class Insight
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Int
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("score")]
    public int score { get; set; }

    [JsonPropertyName("modifier")]
    public object modifier { get; set; }

    [JsonPropertyName("check")]
    public int check { get; set; }

    [JsonPropertyName("isProf")]
    public bool isProf { get; set; }
}

public class Intimidation
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Investigation
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Level
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class Medicine
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Mod
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Name
{
    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Nature
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Perception
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Performance
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Personality
{
    [JsonPropertyName("value")]
    public Value value { get; set; }

    [JsonPropertyName("isHidden")]
    public bool isHidden { get; set; }
}

public class Persuasion
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class PlayerName
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Race
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Religion
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Resource1711187176068
{
    [JsonPropertyName("id")]
    public string id { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("current")]
    public int current { get; set; }

    [JsonPropertyName("max")]
    public int max { get; set; }

    [JsonPropertyName("location")]
    public string location { get; set; }
}

public class Resources
{
    [JsonPropertyName("resource-1711187176068")]
    public Resource1711187176068 resource1711187176068 { get; set; }
}

public class CharacterData
{
    [JsonPropertyName("isDefault")]
    public bool isDefault { get; set; }

    [JsonPropertyName("jsonType")]
    public string jsonType { get; set; }

    [JsonPropertyName("template")]
    public string template { get; set; }

    [JsonPropertyName("name")]
    public Name name { get; set; }

    [JsonPropertyName("info")]
    public Info info { get; set; }

    [JsonPropertyName("subInfo")]
    public SubInfo subInfo { get; set; }

    [JsonPropertyName("spellsInfo")]
    public SpellsInfo spellsInfo { get; set; }

    [JsonPropertyName("spells")]
    public Spells spells { get; set; }

    [JsonPropertyName("proficiency")]
    public int proficiency { get; set; }

    [JsonPropertyName("stats")]
    public Stats stats { get; set; }

    [JsonPropertyName("saves")]
    public Saves saves { get; set; }

    [JsonPropertyName("skills")]
    public Skills skills { get; set; }

    [JsonPropertyName("vitality")]
    public Vitality vitality { get; set; }

    [JsonPropertyName("weaponsList")]
    public List<WeaponsList> weaponsList { get; set; }

    [JsonPropertyName("weapons")]
    public Weapons weapons { get; set; }

    [JsonPropertyName("text")]
    public Text text { get; set; }

    [JsonPropertyName("coins")]
    public Coins coins { get; set; }

    [JsonPropertyName("resources")]
    public Resources resources { get; set; }

    [JsonPropertyName("bonusesSkills")]
    public BonusesSkills bonusesSkills { get; set; }

    [JsonPropertyName("bonusesStats")]
    public BonusesStats bonusesStats { get; set; }

    [JsonPropertyName("conditions")]
    public List<object> conditions { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime createdAt { get; set; }

    [JsonPropertyName("avatar")]
    public Avatar avatar { get; set; }
}

public class Save
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Saves
{
    [JsonPropertyName("str")]
    public Str str { get; set; }

    [JsonPropertyName("dex")]
    public Dex dex { get; set; }

    [JsonPropertyName("con")]
    public Con con { get; set; }

    [JsonPropertyName("int")]
    public Int @int { get; set; }

    [JsonPropertyName("wis")]
    public Wis wis { get; set; }

    [JsonPropertyName("cha")]
    public Cha cha { get; set; }
}

public class Skills
{
    [JsonPropertyName("acrobatics")]
    public Acrobatics acrobatics { get; set; }

    [JsonPropertyName("investigation")]
    public Investigation investigation { get; set; }

    [JsonPropertyName("athletics")]
    public Athletics athletics { get; set; }

    [JsonPropertyName("perception")]
    public Perception perception { get; set; }

    [JsonPropertyName("survival")]
    public Survival survival { get; set; }

    [JsonPropertyName("performance")]
    public Performance performance { get; set; }

    [JsonPropertyName("intimidation")]
    public Intimidation intimidation { get; set; }

    [JsonPropertyName("history")]
    public History history { get; set; }

    [JsonPropertyName("sleight of hand")]
    public SleightOfHand sleightofhand { get; set; }

    [JsonPropertyName("arcana")]
    public Arcana arcana { get; set; }

    [JsonPropertyName("medicine")]
    public Medicine medicine { get; set; }

    [JsonPropertyName("deception")]
    public Deception deception { get; set; }

    [JsonPropertyName("nature")]
    public Nature nature { get; set; }

    [JsonPropertyName("insight")]
    public Insight insight { get; set; }

    [JsonPropertyName("religion")]
    public Religion religion { get; set; }

    [JsonPropertyName("stealth")]
    public Stealth stealth { get; set; }

    [JsonPropertyName("persuasion")]
    public Persuasion persuasion { get; set; }

    [JsonPropertyName("animal handling")]
    public AnimalHandling animalhandling { get; set; }
}

public class Skin
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class SleightOfHand
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Slots1
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class Slots2
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class Speed
{
    [JsonPropertyName("value")]
    public int value { get; set; }
}

public class Spells
{
    [JsonPropertyName("slots-1")]
    public Slots1 slots1 { get; set; }

    [JsonPropertyName("slots-2")]
    public Slots2 slots2 { get; set; }
}

public class SpellsInfo
{
    [JsonPropertyName("base")]
    public Base @base { get; set; }

    [JsonPropertyName("save")]
    public Save save { get; set; }

    [JsonPropertyName("mod")]
    public Mod mod { get; set; }

    [JsonPropertyName("available")]
    public Available available { get; set; }
}

public class Stats
{
    [JsonPropertyName("str")]
    public Str str { get; set; }

    [JsonPropertyName("dex")]
    public Dex dex { get; set; }

    [JsonPropertyName("con")]
    public Con con { get; set; }

    [JsonPropertyName("int")]
    public Int @int { get; set; }

    [JsonPropertyName("wis")]
    public Wis wis { get; set; }

    [JsonPropertyName("cha")]
    public Cha cha { get; set; }
}

public class Stealth
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Str
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("score")]
    public int score { get; set; }

    [JsonPropertyName("modifier")]
    public int modifier { get; set; }

    [JsonPropertyName("check")]
    public int check { get; set; }

    [JsonPropertyName("isProf")]
    public bool isProf { get; set; }
}

public class SubInfo
{
    [JsonPropertyName("age")]
    public Age age { get; set; }

    [JsonPropertyName("height")]
    public Height height { get; set; }

    [JsonPropertyName("weight")]
    public Weight weight { get; set; }

    [JsonPropertyName("eyes")]
    public Eyes eyes { get; set; }

    [JsonPropertyName("skin")]
    public Skin skin { get; set; }

    [JsonPropertyName("hair")]
    public Hair hair { get; set; }
}

public class Survival
{
    [JsonPropertyName("baseStat")]
    public string baseStat { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }
}

public class Text
{
    [JsonPropertyName("personality")]
    public Personality personality { get; set; }

    //[JsonPropertyName("ideals")]
    //public Ideals ideals { get; set; }
}

public class Value
{
    [JsonPropertyName("data")]
    public Data data { get; set; }
}

public class Vitality
{
    [JsonPropertyName("hp-dice-current")]
    public HpDiceCurrent hpdicecurrent { get; set; }

    [JsonPropertyName("hp-dice-multi")]
    public HpDiceMulti hpdicemulti { get; set; }

    [JsonPropertyName("speed")]
    public Speed speed { get; set; }

    [JsonPropertyName("hp-max")]
    public HpMax hpmax { get; set; }

    [JsonPropertyName("hp-current")]
    public HpCurrent hpcurrent { get; set; }

    [JsonPropertyName("hp-temp")]
    public HpTemp hptemp { get; set; }

    [JsonPropertyName("isDying")]
    public bool isDying { get; set; }

    [JsonPropertyName("deathFails")]
    public int deathFails { get; set; }

    [JsonPropertyName("deathSuccesses")]
    public int deathSuccesses { get; set; }

    [JsonPropertyName("ac")]
    public Ac ac { get; set; }
}

public class Weapons
{
}

public class WeaponsList
{
    [JsonPropertyName("id")]
    public string id { get; set; }

    [JsonPropertyName("name")]
    public Name name { get; set; }

    [JsonPropertyName("mod")]
    public Mod mod { get; set; }

    [JsonPropertyName("dmg")]
    public Dmg dmg { get; set; }
}

public class Weight
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("value")]
    public string value { get; set; }
}

public class Wis
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("label")]
    public string label { get; set; }

    [JsonPropertyName("score")]
    public int score { get; set; }

    [JsonPropertyName("modifier")]
    public int modifier { get; set; }

    [JsonPropertyName("check")]
    public int check { get; set; }

    [JsonPropertyName("isProf")]
    public bool isProf { get; set; }
}

