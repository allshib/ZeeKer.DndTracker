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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Гиперссылка")]
    [XafDefaultProperty(nameof(HyperLink))]
    public class HyperlinkObject : BaseObject
    {
        public HyperlinkObject()
        {
            
        }

        [XafDisplayName("Гиперссылка"), StringLength(200)]
        public virtual string HyperLink { get; set; }


        [XafDisplayName("Категория")]
        public virtual HyperlinkCategoryType Category { get; set; }


        [NotMapped, XafDisplayName("Ввод")]
        public virtual string InputLink {
            get { return HyperLink; }
            set { HyperLink = value; }
        }


        [Action(Caption = "Перейти", SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
        public void OpenLink()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = HyperLink,
                    UseShellExecute = true
                };
                Process.Start(processStartInfo);
            }
            catch 
            {
                throw new UserFriendlyException("Не удалось открыть гиперссылку");
            }
        }
    }
}