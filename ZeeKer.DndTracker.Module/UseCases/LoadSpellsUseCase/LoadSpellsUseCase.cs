using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.LoadSpellsUseCase;

public class LoadSpellsUseCase(ISpellParser parser) : ILoadSpellUseCase
{
    public async Task Execute(LoadSpellsCommand request)
    {
        var spellCards = await parser.GetSpellLinks();

        foreach (var spellCard in spellCards)
        {
            var existingSpell = request.ObjectSpace.FindObject<Spell>(CriteriaOperator.Parse("Name = ?", spellCard.Name.Trim()));
            if (existingSpell is not null)
            {
                if (String.IsNullOrEmpty(existingSpell.DndsuLink))
                    existingSpell.DndsuLink = spellCard.FullLink;
                continue;
            }

            var spell = await parser.FindSpell(spellCard)?? await parser.FindSpell(spellCard);

            spell.ToPersistent(request.ObjectSpace);

            Thread.Sleep(100);
        }
    }
}

