using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Contracts.Parsers.SpellParser;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.LoadItemsUseCase;

public class LoadItemsUseCase(IItemParser parser) : ILoadItemsUseCase
{
    public async Task Execute(LoadItemsCommand request)
    {
        var cards = await parser.GetItemLinks();

        foreach (var card in cards)
        {
            var existingItem = request.ObjectSpace.FindObject<Item>(CriteriaOperator.Parse("Name = ?", card.Name.Trim()));
            if (existingItem is not null)
            {
                //if (String.IsNullOrEmpty(existingItem.DndsuLink))
                //    existingItem.DndsuLink = card.FullLink;
                continue;
            }

            var spell = await parser.FindItem(card) ?? await parser.FindItem(card);

            if(spell?.Name is null)
            {
                Thread.Sleep(300);
                spell = await parser.FindItem(card);
            }

            spell.ToPersistent(request.ObjectSpace);

            Thread.Sleep(150);
        }
    }
}

