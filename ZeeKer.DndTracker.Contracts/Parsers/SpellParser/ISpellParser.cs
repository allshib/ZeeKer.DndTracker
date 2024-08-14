using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Contracts.Parsers.SpellParser
{
    public interface ISpellParser
    {
        IAsyncEnumerable<ISpell> GetAllSpells();
        Task<IEnumerable<ISpell>> GetCachedSpells();
        Task<IEnumerable<ISpellLink?>> GetSpellLinksCached(string? html = null);

        Task<ISpell?> FindSpell(string name);
        Task<ISpell?> FindSpell(ISpellLink spellLink);

    }
}
