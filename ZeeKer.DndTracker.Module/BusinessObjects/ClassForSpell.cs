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

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Класс заклинания")]
    //[XafDefaultProperty(nameof(Class))]
    public class ClassForSpell : BaseObject
    {
        public ClassForSpell()
        {
            
        }
        [Browsable(false)]
        public virtual Guid? SpellId { get; set; }

        [ForeignKey(nameof(SpellId)), XafDisplayName("Заклинание")]
        public virtual Spell Spell { get; set; }

        [Browsable(false)]
        public virtual Guid? ClassId { get; set; }

        [ForeignKey(nameof(ClassId)), XafDisplayName("Класс")]
        public virtual CharacterClass Class { get; set; }
    }
}