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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Раса")]
    public class Race : BaseObject
    {
        public Race()
        {
          
        }
        [XafDisplayName("Наименование")]
        public virtual string Name { get; set; }

        [XafDisplayName("Стандартная раса")]
        public virtual RaceType RaceType { get; set; }

        [XafDisplayName("Персонажи")]
        public virtual IList<Character> Characters { get; set; } = new ObservableCollection<Character>();

    }
}