using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Класс персонажа")]
    [XafDefaultProperty(nameof(Name))]
    public class CharacterClass : BaseObject
    {
        public CharacterClass()
        {
            
        }

        [XafDisplayName("Название")]
        public virtual string Name { get; set; }

        [XafDisplayName("Кость хитов")]
        public virtual DiceHitType HealthDice { get; set; }

        [XafDisplayName("Тип")]
        public virtual CharacterClassType ClassType { get; set; }

        [XafDisplayName("Персонажи")]
        public virtual IList<Character> Characters { get; set; } = new ObservableCollection<Character>();

        [XafDisplayName("Заклинания (явная связь)"), Aggregated]
        public virtual IList<ClassForSpell> ClassForSpells { get; set; } = new ObservableCollection<ClassForSpell>();

        [XafDisplayName("Заклинания")]
        public virtual IList<Spell> Spells { get; set; } = new ObservableCollection<Spell>();


        [XafDisplayName("Стандартный инвентарь")]
        public virtual CharacterStorage DefaultStorage { get; set; }


        [XafDisplayName("Источник")]
        public virtual SourceType Source { get; set; }


        public override void OnCreated()
        {
            base.OnCreated();

            CreateLocalStorage();
        }


        public void CreateLocalStorage()
        {
            var storage = ObjectSpace.CreateObject<CharacterStorage>();
            storage.Name = "Стадартный инвентарь";
            storage.Local = true;
            DefaultStorage = storage;
        }
    }
}