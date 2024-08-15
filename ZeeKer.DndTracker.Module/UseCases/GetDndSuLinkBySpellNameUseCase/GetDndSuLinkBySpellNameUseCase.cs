using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;

namespace ZeeKer.DndTracker.Module.UseCases.GetDndSuLinkBySpellNameUseCase
{
    public class GetDndSuLinkBySpellNameUseCase(ISpellParser parser) : IGetDndSuLinkBySpellNameUseCase
    {
        public async Task Execute(GetDndSuLinkBySpellNameCommand request)
        {
            var spells = await parser.GetSpellLinksCached();

            var spell = spells.FirstOrDefault(s => s.Name == request.Spell.Name);

            if (spell is not null)
                request.Spell.DndsuLink = spell.FullLink;
            else
                throw new UserFriendlyException("Не удалось найти ссылку на Dnd.su");
            
        }
    }
}
