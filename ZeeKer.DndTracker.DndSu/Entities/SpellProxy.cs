using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
namespace ZeeKer.DndTracker.DndSu.Entities;


public record SpellProxy(
    string Name,
    string EnglishName,
    string SpellLevel,
    string MagicSchool,
    string SpellCastingTime,
    string Distance,
    string Components,
    string Duration,
    bool NeedConcentration,
    bool IsRitual,
    string Classes,
    string Source,
    string Description,
    string FullLink) : ISpell;


