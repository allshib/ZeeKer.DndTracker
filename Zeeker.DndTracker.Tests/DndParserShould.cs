using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeeker.DndTracker.Tests.Mock;
using ZeeKer.DndTracker.DndSu;
using ZeeKer.DndTracker.DndSu.Parsers;

namespace Zeeker.DndTracker.Tests;

public class DndParserShould : TestBase
{




    //[Fact]

    //public async Task ParseSimpleSpells()
    //{
    //    var parser = new DndsuParser();
    //    await foreach(var spell in parser.Get)
    //    {

    //    }
    //}


    [Fact]

    public async Task ParseSpell()
    {
        var parser = new DndsuSpellParser();
        await parser.GetSpellCard("https://dnd.su/spells/1-hellish_rebuke/");
    }


    [Fact]

    public async Task ParseSpells()
    {
        var parser = new DndsuSpellParser();
        await foreach(var spell in parser.GetAllSpells())
        {
            var spellCard = spell;
        }
    }



    //[Fact]

    //public async Task TestError()
    //{
    //    var parser = new DndsuParser();
    //    var card = (await parser.GetSpellCardsList()).First(x=>x.Name == "Волшебная рука");

    //    var spell = await parser.GetSpellCard(card.FullLink);
    //}
}

