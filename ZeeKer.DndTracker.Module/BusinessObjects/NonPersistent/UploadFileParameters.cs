using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent
{
    [DomainComponent]
    public class UploadFileParameters : NonPersistentObjectImpl
    {
        private FileData file;
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        [RuleRequiredField("Save", "File should be assigned")]
        public FileData File
        {
            get { return file; }
            set { SetPropertyValue(ref file, value); }
        }
    }
}
