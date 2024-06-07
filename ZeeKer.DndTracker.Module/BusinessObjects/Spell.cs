using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Заклинание")]
    [XafDefaultProperty(nameof(FullName))]
    public class Spell : BaseObject
    {
        public Spell()
        {

        }
        [NotMapped, XafDisplayName("Полное наименование")]
        public virtual string FullName => $"{Name} ({(SpellLevel == 0? "Заговор":$"{SpellLevel} уровень")}, {CaptionHelper.GetDisplayText(MagicSchool)}{(IsRitual?" (Ритуал)":"")})";

        [XafDisplayName("Наименование"), StringLength(170)]
        public virtual string Name { get; set; }

        [XafDisplayName("Школа")]
        public virtual MagicSchoolType MagicSchool { get; set; }


        [XafDisplayName("Уровень заклинания")]
        public virtual int SpellLevel { get; set; }


        [XafDisplayName("Описание"), StringLength(1700)]
        public virtual string Descripton { get; set; }

        [XafDisplayName("Компоненты"), StringLength(300)]
        public virtual string Components { get; set; }

        [XafDisplayName("Длительность"), StringLength(150)]
        public virtual string Duration { get; set; }

        [XafDisplayName("Дистанция"), StringLength(100)]
        public virtual string Distance { get; set; }

        [XafDisplayName("Время накладывания"), StringLength(150)]
        public virtual string SpellCastingTime { get; set; }

        [XafDisplayName("Концентрация")]
        public virtual bool NeedConcentration { get; set; }

        [XafDisplayName("Ритуал")]
        public virtual bool IsRitual { get; set; }

        [XafDisplayName("Источник")]
        public virtual SourceType Source { get; set; }

        //[XafDisplayName("Классы")]
        //public virtual string Classes => String.Join(", ", ClassForSpells.Select(x => $"{x.Class?.Name}"));

        [XafDisplayName("Связанные классы (явная связь)"), Aggregated]
        public virtual IList<ClassForSpell> ClassForSpells { get; set; } = new ObservableCollection<ClassForSpell>();

        [XafDisplayName("Связанные классы")]
        public virtual IList<CharacterClass> ClassObjects { get; set; } = new ObservableCollection<CharacterClass>();
    }
}