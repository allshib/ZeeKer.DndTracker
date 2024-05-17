using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Extensions
{
    internal static class CharacterEx
    {
        /// <summary>
        /// Использовать только на сохраненных сущностях
        /// </summary>
        /// <param name="characters"></param>
        public static void Fix(this IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                character.Fix();
            }
        }

        /// <summary>
        /// Использовать только на сохраненных сущностях
        /// </summary>
        /// <param name="characters"></param>
        public static void Fix(this Character character)
        {
            character.Stats.CharacterId = character.ID;
        }


    }
}
