using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.StateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Extensions
{
    internal static class EFModelBuilderEx
    {


        public static void ApplyOldAssociations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateMachine>()
            .HasMany(t => t.States)
            .WithOne(t => t.StateMachine)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ModelDifference>()
                .HasMany(t => t.Aspects)
                .WithOne(t => t.Owner)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
            .HasOne(t => t.Person)
            .WithMany(t => t.Characters)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StorageOperation>()
            .HasOne(op => op.Storage)
            .WithMany(storage => storage.Operations);
            //.OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<StorageOperation>()
                .HasOne(op => op.StorageSource)
                .WithMany(storage => storage.OperationsFromThis);
            //.OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<Character>()
                .HasOne(ch => ch.Class)
                .WithMany(ch => ch.Characters)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Character>()
            .HasMany(ch => ch.Storages)
            .WithOne(st => st.Character)
            .OnDelete(DeleteBehavior.SetNull);




            modelBuilder.Entity<SkillDetail>()
                .HasOne(x => x.Skills)
                .WithMany(x => x.SkillDetails)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
            .HasOne(ch => ch.Race)
            .WithMany(race => race.Characters)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Item>()
                .HasMany(item => item.AssignedItems)
                .WithOne(ass => ass.Item)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CharacterStorage>()
                .HasMany(st => st.Items)
                .WithOne(ass => ass.Storage)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Character>()
                .HasMany(ch => ch.Profiencies)
                .WithOne(ch => ch.Character)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profiency>()
                .HasMany(p => p.Items)
                .WithOne(i => i.Profiency)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Feat>()
                .HasMany(f => f.Bonuses)
                .WithOne(ab => ab.Feat)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StatBonus>()
                .HasMany(sb => sb.BonusGroups)
                .WithOne(g => g.Bonus)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StatBonusGroup>()
                .HasMany(g => g.StatBonuses)
                .WithOne(sb => sb.Group)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasMany(g => g.AvailableFeats)
                .WithOne(sb => sb.Character)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Spell>()
            .HasMany(s => s.ClassForSpells)
            .WithOne(cs => cs.Spell)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterClass>()
                .HasMany(s => s.ClassForSpells)
                .WithOne(cs => cs.Class)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasMany(ch => ch.AvailableSpells)
                .WithOne(s => s.Character)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Campain>()
            .HasMany(c => c.HyperLinks)
            .WithOne(h => h.Campain)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
