using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Remote.Linq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Extensions
{
    public static class BaseObjectEx
    {

        public static IObjectSpace GetObjectSpace(this BaseObject baseObject)
        {
            var type = typeof(IObjectSpaceLink);

            var property = type
                .GetProperty("ObjectSpace");

            if(property is not null )
                return property.GetValue(baseObject) as IObjectSpace;

            return null;
        }


        public static void Delete(this BaseObject baseObject)
        {
            var os = GetObjectSpace(baseObject);

            os.Delete(baseObject);
        }

        public static void Reload(this BaseObject baseObject)
        {
            var os = GetObjectSpace(baseObject);

            os.ReloadObject(baseObject);
        }

        public static bool IsMatchedFor(this BaseObject baseObject, string criteria)
        {
            var os = baseObject.GetObjectSpace();
            var result = os.IsObjectFitForCriteria(baseObject, CriteriaOperator.Parse(criteria));
            return result?? false;
        }
    }
}
