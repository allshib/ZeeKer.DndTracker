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


    public static void CustomMapTo(this Character source, Character target, bool withStorage = false)
    {


        source.MapTo(target);
        source.Info.MapTo(target.Info);
        source.Stats.MapTo(target.Stats);

        foreach (var skill in source.Stats.Skills.SkillDetails)
        {
            var newSkill = target.Stats.Skills.SkillDetails.FirstOrDefault(x => x.SkillType == skill.SkillType);

            skill.MapTo(newSkill);
        }

        
        
        


        var osTarget = target.GetObjectSpace();

        if (withStorage)
            source.LocalStorage.CustomMapTo(target.LocalStorage);
        


        foreach (var spell in source.AvailableSpells)
        {
            if (target.AvailableSpells.Any(x => x.SpellId == spell.SpellId))
                continue;

            var assignedSpell = osTarget.CreateObject<AvailableSpell>();
            assignedSpell.SpellId = spell.SpellId;
            assignedSpell.Character = target;
        }

        foreach (var profiency in source.Profiencies)
        {
            if(target.Profiencies.Any(x => x.ProfiencyId == profiency.ProfiencyId))
                continue;

            var assignedProfiency = osTarget.CreateObject<AssignedProfiency>();
            assignedProfiency.ProfiencyId = profiency.ProfiencyId;
            assignedProfiency.ItemId = profiency.ItemId;
            assignedProfiency.Character = target;
        }

        foreach(var feat in source.AvailableFeats)
        {
            if (target.AvailableFeats.Any(x => x.FeatId == feat.FeatId))
                continue;

            var assignedFeat = osTarget.CreateObject<AvailableFeat>();
            assignedFeat.Character = target;
            assignedFeat.FeatId = feat.FeatId;
            assignedFeat.Description = feat.Description;
            assignedFeat.LevelAdded = feat.LevelAdded;
            assignedFeat.Name = feat.Name;
            assignedFeat.SelectedBonuses = feat.SelectedBonuses;
        }
    }
}

