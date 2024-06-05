using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeeKer.DndTracker.Module.Extensions
{
    public static class ObjectSpaceEx
    {

        public static bool Exists<T>(this IObjectSpace objectSpace,CriteriaOperator criteria) where T : BaseObject
        {
            return objectSpace.FindObject<T>(criteria) is not null;
        }
    }
}
