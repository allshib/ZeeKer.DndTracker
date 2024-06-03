using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent;
using ZeeKer.DndTracker.Module.Extensions;
using ZeeKer.DndTracker.Module.Types;
using StatBonus = ZeeKer.DndTracker.Module.BusinessObjects.StatBonus;

namespace ZeeKer.DndTracker.Module.UseCases.SelectFeatUseCase
{
    internal class SelectFeatForCharacterUseCase : ShowViewUseCaseBase
    {
        public SelectFeatForCharacterUseCase(XafApplication application) : base(application)
        {
        }



        public void Execute(Character character)
        {
            var characterObjectSpace = character.GetObjectSpace();
            var entity = new SelectFeatViewModel(characterObjectSpace.GetObjects<Feat>());
            var os = application.CreateObjectSpace(typeof(SelectFeatViewModel));
            var dv = CreateDetailView(entity, os);

            this.OpenDetailView(dv, () => {

                if (entity.Feat is null || character.AvailableFeats.Any(x => x.FeatId == entity.Feat.ID))
                {
                    dv.Close();
                    return;
                }
                    



                var feat = characterObjectSpace.CreateObject<AvailableFeat>();
                feat.Name = entity.Feat.Name;
                feat.Description = entity.Feat.Description;
                feat.FeatId = entity.Feat.ID;
                feat.Character = character;
                feat.LevelAdded = character.Level;

                if (entity.Feat.Bonuses.Any())
                    EnableBonuses(entity.Feat, feat);

                
                //characterObjectSpace.CommitChanges();

                
            });

        }

        private void EnableBonuses(Feat feat, AvailableFeat aFeat)
        {
            if(feat.Bonuses.Where(x=>x.Bonus?.Type == BonusType.Stat).Any())
            {
                var statBonusonus = feat.Bonuses.First(b => b.Bonus.Type == BonusType.Stat).Bonus as StatBonus;

                if (statBonusonus.BonusGroups.Count() == 1)
                {
                    var statsBonusList = statBonusonus.BonusGroups.First().StatBonuses;

                    if (statsBonusList.Where(b => b.BonusType == StatBonusType.Any).Any() == false)
                    {
                        aFeat.SelectedBonuses = new AvailableFeatJson
                        {
                            StatBonus = new StatBonusJson
                            {
                                Strength = statsBonusList.Where(b => b.BonusType == StatBonusType.Strength).Sum(b => b.StatBonus),
                                Dexterity = statsBonusList.Where(b => b.BonusType == StatBonusType.Dexterity).Sum(b => b.StatBonus),
                                Constitution = statsBonusList.Where(b => b.BonusType == StatBonusType.Constitution).Sum(b => b.StatBonus),
                                Intelligence = statsBonusList.Where(b => b.BonusType == StatBonusType.Intelligence).Sum(b => b.StatBonus),
                                Wisdom = statsBonusList.Where(b => b.BonusType == StatBonusType.Wisdom).Sum(b => b.StatBonus),
                                Charisma = statsBonusList.Where(b => b.BonusType == StatBonusType.Charisma).Sum(b => b.StatBonus)
                            }


                        };
                    }
                }


                if(aFeat.SelectedBonuses?.StatBonus is not null)
                {
                    aFeat.Character.Stats.Strength += aFeat.SelectedBonuses.StatBonus.Strength;
                    aFeat.Character.Stats.Dexterity += aFeat.SelectedBonuses.StatBonus.Dexterity;
                    aFeat.Character.Stats.Constitution += aFeat.SelectedBonuses.StatBonus.Constitution;
                    aFeat.Character.Stats.Intelegence += aFeat.SelectedBonuses.StatBonus.Intelligence;
                    aFeat.Character.Stats.Wisdom += aFeat.SelectedBonuses.StatBonus.Wisdom;
                    aFeat.Character.Stats.Charisma += aFeat.SelectedBonuses.StatBonus.Charisma;
                }
            }
        }
    }
}
