using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.Types;
using DevExpress.Persistent.BaseImpl.EF;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Навык")]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public class SkillDetail : BaseObject
    {
        public SkillDetail() : base() { }

        public virtual string DefaultProperty => $"{SkillType} ({Value})";

        [XafDisplayName("Значение")]
        public virtual int Value { get; set; }
        [XafDisplayName("Владение")]
        public virtual bool HasSkill { get; set; }
        [XafDisplayName("От чего зависит")]
        public virtual SkillDependencyType Dependency { get; set; }
        [XafDisplayName("Навык")]
        public virtual SkillType SkillType { get; set; }


        [ForeignKey(nameof(SkillsId))]
        [XafDisplayName("Навыки")]
        public virtual Skills Skills { get; set; }
        [Browsable(false)]
        public virtual Guid? SkillsId { get; set; }
    }
}
