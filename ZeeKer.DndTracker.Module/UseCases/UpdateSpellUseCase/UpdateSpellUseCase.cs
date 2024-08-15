using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.UpdateSpellUseCase
{
    public class UpdateSpellUseCase(ISpellParser parser) : IUpdateSpellUseCase
    {
        public async Task Execute(UpdateSpellCommand request)
        {
            var spellProxy = await parser.FindSpell(request.Spell.Name);

            if (spellProxy is not null)
                spellProxy.MapTo(request.Spell);
            else
                request.Spell.LoadResult = Types.LoadSpellResult.LoadFailed;
            
        }
    }
}
