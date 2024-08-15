using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Contracts.Parsers.SpellParser
{
    public interface ISpellParser
    {
        /// <summary>
        /// Метод получения всех заклинаний
        /// </summary>
        /// <returns></returns>
        IAsyncEnumerable<ISpell> GetAllSpells();

        /// <summary>
        /// Метод получение заклинания по из кеша
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ISpell>> GetCachedSpells();

        /// <summary>
        /// Метод получения всех ссылок на заклинания
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        Task<IEnumerable<ISpellLink?>> GetSpellLinks(string? html = null);

        /// <summary>
        /// Метод поиска заклинания по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ISpell?> FindSpell(string name);

        /// <summary>
        /// Метод поиска заклинания по ссылке
        /// </summary>
        /// <param name="spellLink"></param>
        /// <returns></returns>
        Task<ISpell?> FindSpell(ISpellLink spellLink);

    }
}
