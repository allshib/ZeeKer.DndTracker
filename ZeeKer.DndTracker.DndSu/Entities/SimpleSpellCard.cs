using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;

namespace ZeeKer.DndTracker.DndSu.Entities;


public record SimpleSpellCard(string Name, string FullLink) : ISpellLink;


