using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.SelectCharactersUseCase
{
    internal class SelectAndLoadCharacterUseCase : ShowViewUseCaseBase
    {
        public SelectAndLoadCharacterUseCase(XafApplication application) : base(application)
        {
        }


        public void ShowDialog(List<CharacterData> characters, IObjectSpace persistentObjectSpace)
        {
            var entity = new CharacterDataList(characters);
            var os = application.CreateObjectSpace(typeof(CharacterDataList));
            var dv = this.CreateDetailView(entity, os);

            this.OpenDetailView(dv, () =>
            {
                var selectedChatacters = entity.CharacterDataItems
                .Where(ch => ch.Selected)
                .Select(ch=>ch.Character)
                .ToList();
                LoadCharacters(selectedChatacters, persistentObjectSpace);
            });
        }


        private void LoadCharacters(List<CharacterData> selectedCharacters, IObjectSpace persistentObjectSpace)
        {
            var newCharacters = new List<Character>();
            foreach (var selectedCharacter in selectedCharacters)
            {
                var character = persistentObjectSpace.CreateObject<Character>();
                newCharacters.Add(character);

                character.Name = selectedCharacter.name?.value;
                character.Level = selectedCharacter.info?.level?.value?? 1;
                character.Class = persistentObjectSpace
                    .FindObject<CharacterClass>(CriteriaOperator
                    .Parse($"{nameof(Name)} = ?", selectedCharacter.info?.charClass?.value??""));

                character.Stats.Strength = selectedCharacter.stats?.str?.score?? 0;
                character.Stats.Wisdom = selectedCharacter.stats?.wis?.score?? 0;
                character.Stats.Dexterity = selectedCharacter.stats?.dex?.score ?? 0;
                character.Stats.Intelegence = selectedCharacter.stats?.@int?.score ?? 0;
                character.Stats.Charisma = selectedCharacter.stats?.cha?.score ?? 0;
                character.Stats.Constitution = selectedCharacter.stats?.con?.score ?? 0;

                character.Info.Aligment = selectedCharacter.info?.alignment?.value;
                character.Info.Age = GetIntValue(selectedCharacter.subInfo?.age?.value);
                character.Info.Weight = GetIntValue(selectedCharacter.subInfo?.weight?.value);
                character.Info.Height = GetIntValue(selectedCharacter.subInfo?.height?.value);
                character.Info.Eyes = selectedCharacter.subInfo?.eyes?.value;
                character.Info.Hair = selectedCharacter.subInfo?.hair?.value;
                
                SetSkills(character.Stats.Skills, selectedCharacter.skills);

                character.Campain = persistentObjectSpace
                    .FindObject<Campain>(CriteriaOperator
                    .Parse($"{nameof(Name)} = ?", "Пустой"));
            }
            persistentObjectSpace.CommitChanges();

            //newCharacters.Fix();

            persistentObjectSpace.CommitChanges();
            persistentObjectSpace.Refresh();
        }

        private void SetSkills(BusinessObjects.Skills skills, Skills skillsEntity)
        {
            if (skills is null || skillsEntity is null)
                return;

            skills.Acrobatics.HasSkill = IntToBool(skillsEntity?.acrobatics?.isProf);
            skills.AnimalHandling.HasSkill = IntToBool(skillsEntity?.animalhandling?.isProf);
            skills.Arcana.HasSkill = IntToBool(skillsEntity?.arcana?.isProf);
            skills.Athletics.HasSkill = IntToBool(skillsEntity?.athletics?.isProf);
            skills.Deception.HasSkill = IntToBool(skillsEntity?.deception?.isProf);
            skills.History.HasSkill = IntToBool(skillsEntity?.history?.isProf);
            skills.Insight.HasSkill = IntToBool(skillsEntity?.insight?.isProf);
            skills.Intimidation.HasSkill = IntToBool(skillsEntity?.intimidation?.isProf);
            skills.Investigation.HasSkill = IntToBool(skillsEntity?.investigation?.isProf);
            skills.Medicine.HasSkill = IntToBool(skillsEntity?.medicine?.isProf);
            skills.Nature.HasSkill = IntToBool(skillsEntity?.nature?.isProf);
            skills.Perception.HasSkill = IntToBool(skillsEntity?.perception?.isProf);
            skills.Performance.HasSkill = IntToBool(skillsEntity?.performance?.isProf);
            skills.Persuasion.HasSkill = IntToBool(skillsEntity?.persuasion?.isProf);
            skills.Religion.HasSkill = IntToBool(skillsEntity?.religion?.isProf);
            skills.SleightOfHand.HasSkill = IntToBool(skillsEntity?.sleightofhand?.isProf);
            skills.Stealth.HasSkill = IntToBool(skillsEntity?.stealth?.isProf);
            skills.Survival.HasSkill = IntToBool(skillsEntity?.survival?.isProf);
        }

        private bool IntToBool(int? isProf)
        {
            switch(isProf)
            {
                case 1: return true;
                default: return false;
            }

        }

        private int GetIntValue(string value)
        {
            if(String.IsNullOrEmpty(value)) return 0;

            Int32.TryParse(value, out var valueInt);
            return valueInt;
        }
    }
}
