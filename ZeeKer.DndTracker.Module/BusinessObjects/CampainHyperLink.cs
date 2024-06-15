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
    [XafDisplayName("Гиперссылка камппейна")]
    public class CampainHyperLink : HyperlinkObject
    {
        public CampainHyperLink()
        {
            
        }

        [Browsable(false)]
        public virtual Guid? CampainId { get; set; }

        [XafDisplayName("Кампейн"), ForeignKey(nameof(CampainId))]
        public virtual Campain Campain { get; set; }
        
    }
}