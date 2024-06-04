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
            var os = application.CreateObjectSpace(typeof(SelectFeatViewModel));
            var entity = os.CreateObject<SelectFeatViewModel>();
            entity.Feats = characterObjectSpace.GetObjects<Feat>();
            
            var dv = CreateDetailView(entity, os);

            this.OpenDetailView(dv, () =>
            {
                
                if (entity.Feat is null || character.AvailableFeats.Any(x => x.FeatId == entity.Feat.ID))
                {
                    dv.Close();
                    return;
                }

                if(String.IsNullOrEmpty(entity.Feat.Condition) == false && 
                character.IsMatchedFor(entity.Feat.Condition) == false)
                {
                    throw new UserFriendlyException("Персонаж не соответствует условию черты");
                }


                var feat = characterObjectSpace.CreateObject<AvailableFeat>();
                feat.Name = entity.Feat.Name;
                feat.Description = entity.Feat.Description;
                feat.FeatId = entity.Feat.ID;
                feat.Character = character;
                feat.LevelAdded = character.Level;

                if (entity.Feat.Bonuses.Any())
                    EnableStatBonuses(entity, feat);


                //characterObjectSpace.CommitChanges();


            });

        }

        private void EnableStatBonuses(SelectFeatViewModel viewModel, AvailableFeat aFeat)
        {
            if (viewModel.StatBonus is null)
                return;

            if (viewModel.StattBonusGroup is null)
            {
                aFeat.Delete();
                throw new UserFriendlyException("Не выбрана группа бонусов характеристик");
            }

            FillStatBonusJson(viewModel, aFeat);

            aFeat.EnableBonusesFromJson();
        }

        private void FillStatBonusJson(SelectFeatViewModel viewModel, AvailableFeat aFeat)
        {
            var statBonus = viewModel.StatBonus;

            var selectedBonuses = viewModel.StatSelectObjects;

            if (selectedBonuses.Any(x => x.BonusType == StatBonusType.Any))
            {
                aFeat.Delete();
                throw new UserFriendlyException("Не выбран бонус");
            }

            
            FillSimpleVariant(viewModel.StattBonusGroup, aFeat, selectedBonuses);
            

        }

        private void FillSimpleVariant(StatBonusGroup group, AvailableFeat aFeat, List<StatSelectObject> selectStats)
        {
            var statsBonusList = group.StatBonuses;


            aFeat.SelectedBonuses = new AvailableFeatJson
            {
                StatBonus = new StatBonusJson
                {
                    Strength = 
                        statsBonusList
                            .Where(b => b.BonusType == StatBonusType.Strength)
                            .Sum(b => b.StatBonus) + 
                        selectStats
                            .Where(b=>b.BonusType == StatBonusType.Strength)
                            .Sum(b=>b.Bonus),
                    Dexterity = 
                        statsBonusList
                            .Where(b => b.BonusType == StatBonusType.Dexterity)
                            .Sum(b => b.StatBonus) +
                        selectStats
                            .Where(b => b.BonusType == StatBonusType.Dexterity)
                            .Sum(b => b.Bonus),
                    Constitution =
                        statsBonusList
                            .Where(b => b.BonusType == StatBonusType.Constitution)
                            .Sum(b => b.StatBonus) +
                        selectStats
                            .Where(b => b.BonusType == StatBonusType.Constitution)
                            .Sum(b => b.Bonus),
                    Intelligence =
                        statsBonusList
                            .Where(b => b.BonusType == StatBonusType.Intelligence)
                            .Sum(b => b.StatBonus) +
                        selectStats
                            .Where(b => b.BonusType == StatBonusType.Intelligence)
                            .Sum(b => b.Bonus),
                    Wisdom =
                        statsBonusList
                            .Where(b => b.BonusType == StatBonusType.Wisdom)
                            .Sum(b => b.StatBonus) +
                        selectStats
                            .Where(b => b.BonusType == StatBonusType.Wisdom)
                            .Sum(b => b.Bonus),
                    Charisma =
                        statsBonusList
                            .Where(b => b.BonusType == StatBonusType.Charisma)
                            .Sum(b => b.StatBonus) +
                        selectStats
                            .Where(b => b.BonusType == StatBonusType.Charisma)
                            .Sum(b => b.Bonus)
                }


            };
            
        }
    }
}
