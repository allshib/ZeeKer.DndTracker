using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Contracts.Parsers.SpellParser
{
    public interface ISpell
    {
        string Name { get; }
        string Description { get; }
        string SpellLevel { get; }
        string MagicSchool { get; }
        string SpellCastingTime { get; }
        string Distance { get; }
        string Components { get; }
        string Duration { get; }
        string Classes { get; }
        string Source { get; }
        string FullLink { get; }

        bool IsRitual { get; }
        bool NeedConcentration { get; }

    }
}
