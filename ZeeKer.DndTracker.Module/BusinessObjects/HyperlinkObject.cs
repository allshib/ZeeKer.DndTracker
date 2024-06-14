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
    [XafDisplayName("�����������")]
    [XafDefaultProperty(nameof(HyperLink))]
    public class HyperlinkObject : BaseObject
    {
        public HyperlinkObject()
        {
            
        }

        [XafDisplayName("�����������"), StringLength(200)]
        public virtual string HyperLink { get; set; }


        [XafDisplayName("���������")]
        public virtual HyperlinkCategoryType Category { get; set; }


        [NotMapped, XafDisplayName("����")]
        public virtual string InputLink {
            get { return HyperLink; }
            set { HyperLink = value; }
        }


        [Action(Caption = "�������", SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
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
                throw new UserFriendlyException("�� ������� ������� �����������");
            }
        }
    }
}