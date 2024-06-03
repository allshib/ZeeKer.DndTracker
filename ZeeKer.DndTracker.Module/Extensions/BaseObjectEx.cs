using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
    }
}
