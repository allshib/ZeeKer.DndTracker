using DevExpress.ExpressApp;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.Mappers;


[Mapper]
public static partial class CharacterMapperEx
{


    [MapperIgnoreSource(nameof(Character.ID))]
    [MapperIgnoreTarget(nameof(Character.ID))]
    public static partial void MapTo(this Character source, Character target);


    public static void CustomMapTo(this Character source, Character target)
    {


        source.MapTo(source);
        source.Info.MapTo(source.Info);
        source.Stats.MapTo(source.Stats);

        foreach (var skill in source.Stats.Skills.SkillDetails)
        {
            var newSkill = target.Stats.Skills.SkillDetails.FirstOrDefault(x => x.SkillType == skill.SkillType);

            skill.MapTo(newSkill);
        }

        source.LocalStorage.MapTo(target.LocalStorage);
        var osTarget = target.GetObjectSpace();

        foreach (var spell in source.AvailableSpells)
        {
            if (target.AvailableSpells.Any(x => x.SpellId == spell.SpellId))
                continue;

            var assignedSpell = osTarget.CreateObject<AvailableSpell>();
            assignedSpell.SpellId = spell.SpellId;
            assignedSpell.Character = target;
        }
    }
}

