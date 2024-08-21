using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.ItemParser;

namespace ZeeKer.DndTracker.Contracts.Parsers.SpellParser
{
    public interface IItemParser
    {
        /// <summary>
        /// Метод получения всех заклинаний
        /// </summary>
        /// <returns></returns>
        IAsyncEnumerable<IItem> GetAllItems();

        /// <summary>
        /// Метод получение заклинания по из кеша
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IItem>> GetCachedItems();

        /// <summary>
        /// Метод получения всех ссылок на заклинания
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        Task<IEnumerable<IItemLink?>> GetItemLinks(string? html = null);

        /// <summary>
        /// Метод поиска заклинания по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IItem?> FindItem(string name);

        /// <summary>
        /// Метод поиска заклинания по ссылке
        /// </summary>
        /// <param name="itemLink"></param>
        /// <returns></returns>
        Task<IItem?> FindItem(IItemLink itemLink);

    }
}
