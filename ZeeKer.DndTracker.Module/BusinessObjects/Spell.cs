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
    [XafDisplayName("����������")]
    [XafDefaultProperty(nameof(FullName))]
    public class Spell : BaseObject
    {
        public Spell()
        {

        }
        [NotMapped, XafDisplayName("������ ������������")]
        public virtual string FullName => $"{Name} ({(SpellLevel == 0? "�������":$"{SpellLevel} �������")}, {CaptionHelper.GetDisplayText(MagicSchool)})";

        [XafDisplayName("������������"), StringLength(170)]
        public virtual string Name { get; set; }

        [XafDisplayName("�����")]
        public virtual MagicSchoolType MagicSchool { get; set; }


        [XafDisplayName("������� ����������")]
        public virtual int SpellLevel { get; set; }


        [XafDisplayName("��������"), StringLength(1700)]
        public virtual string Descripton { get; set; }

        [XafDisplayName("����������"), StringLength(300)]
        public virtual string Components { get; set; }

        [XafDisplayName("������������"), StringLength(150)]
        public virtual string Duration { get; set; }

        [XafDisplayName("���������"), StringLength(100)]
        public virtual string Distance { get; set; }

        [XafDisplayName("����� ������������"), StringLength(150)]
        public virtual string SpellCastingTime { get; set; }

        [XafDisplayName("������������")]
        public virtual bool NeedConcentration { get; set; }

        [XafDisplayName("��������")]
        public virtual SourceType Source { get; set; }

        [XafDisplayName("������")]
        public virtual string Classes => String.Join(", ", ClassForSpells.Select(x => $"{x.Class?.Name}"));

        [XafDisplayName("��������� ������"), Aggregated]
        public virtual IList<ClassForSpell> ClassForSpells { get; set; } = new ObservableCollection<ClassForSpell>();
    }
}