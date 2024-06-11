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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Документация")]
    [XafDefaultProperty(nameof(Name))]
    public class DocumentationInfo : BaseObject
    {
        public DocumentationInfo()
        {

            if (String.IsNullOrEmpty(ObjectTypeName))
            {
                ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(ObjectTypeName);
                objectType = typeInfo is null ? null : typeInfo.Type;
            }
        }

        [XafDisplayName("Наименование"), StringLength(150)]
        public virtual string Name { get; set; }

        [StringLength(300)]
        public virtual string ObjectTypeName
        {
            get { return objectType == null ? string.Empty : objectType.FullName; }
            set
            {
                ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(value);
                objectType = typeInfo == null ? null : typeInfo.Type;
            }
        }
        private Type objectType;
        [NotMapped, ImmediatePostData, XafDisplayName("Тип объекта")]
        public Type ObjectType
        {
            get { return objectType; }
            set
            {
                if (objectType == value)
                    return;
                objectType = value;
            }
        }


        [XafDisplayName("Ссылка на документацию"), StringLength(250)]
        public virtual string Link { get; set; }

        [XafDisplayName("Активно")]
        public virtual bool Active { get; set; }

    }
}