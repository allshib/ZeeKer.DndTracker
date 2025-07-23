using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Validation.AllContextsView;
using DevExpress.Internal;
using DevExpress.Licensing;
using DevExpress.Utils.About;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using static Aqua.Text.Json.Converters.JsonConverterHelper;

namespace ZeeKer.DndTracker.Blazor.Server.Helpers;

public static class BlazorLicenseHelper
{
    private static int version;
    private static long licensedProducts;
    private static long licensedSources;
    private static string userName;
    private static int userNo;
    private static int keyNumber;
    private static string uniqueId;
    private static bool isValid;
    private static DateTime expiration;

    public static void ActivateLicense()
    {
        var providersField = typeof(LicenseManager).GetField("s_providers", BindingFlags.NonPublic | BindingFlags.Static);
        var user = GetUser();
        var providersTable = new Hashtable();
        providersTable.Add(typeof(SystemModule), new ZeekerLicenseProvider());
        providersTable.Add(typeof(XtraReport), new ZeekerLicenseProvider());
        providersTable.Add(typeof(DevExpressServiceCollectionExtensions), new ZeekerLicenseProvider()); 
        providersTable.Add(
            typeof(DevExpress.Blazor.Reporting.DxReportViewer).Assembly.GetType("Microsoft.Extensions.DependencyInjection.StartupExtensions"), 
            new ZeekerLicenseProvider());
                
        providersField.SetValue(null, providersTable);  
    }

    private static UserData GetUser()
    {
        var user = new UserData();
        var userType = typeof(UserData);

        var licensedProducts = userType.GetField("licensedProducts",
            BindingFlags.Instance | BindingFlags.NonPublic);

        var userNo = userType.GetField("userNo",
            BindingFlags.Instance | BindingFlags.NonPublic);

        var isValid = userType.GetField("isValid",
            BindingFlags.Instance | BindingFlags.NonPublic);

        var expiration = userType.GetField("expiration",
            BindingFlags.Instance | BindingFlags.NonPublic);

        //expiration.SetValue(user, DateTime.MinValue);
        //isValid.SetValue(user, true);
        //userNo.SetValue(user, 1);
        licensedProducts.SetValue(user, (long)0L);

        //var empty = userType.GetField("empty", BindingFlags.NonPublic | BindingFlags.Static);
        //empty.SetValue(null, user);

        SetPrivateStaticReadonlyField<UserData>("empty", user);
        var test = "251,0,0,FULL,1,1,someId->00010101";
        var parse = userType.GetMethod("Parse",
            BindingFlags.Instance | BindingFlags.NonPublic);
        parse.Invoke(user, [test]);
        //Parse(test);
        var em = UserData.Empty;

        return user;
    }
    internal static void Parse(string text)
    {
        if (text == null || text.Length == 0)
        {
            return;
        }

        string[] array = text.Split(",", 7);
        if (array.Length != 7)
        {
            return;
        }

        try
        {
            version = Convert.ToInt32(array[0]);
            if (251 != version)
            {
                return;
            }

            licensedProducts = Convert.ToInt64(array[1]);
            licensedSources = Convert.ToInt64(array[2]);
            userName = array[3];
            userNo = Convert.ToInt32(array[4]);
            keyNumber = Convert.ToInt32(array[5]);
            uniqueId = array[6];
            CheckForExpirationDate(ref uniqueId);
            UpdateUserName();
            isValid = true;
        }
        catch
        {
        }
    }

    private static void UpdateUserName()
    {
        
    }

    private static void CheckForExpirationDate(ref string uniqueId)
    {
        int num = uniqueId.IndexOf("->");
        if (num >= 0)
        {
            string s = uniqueId.Substring(num + 2);
            uniqueId = uniqueId.Substring(0, num);
            if (int.TryParse(s, out var _) && DateTime.TryParseExact(s, "yyyyMMdd", null, DateTimeStyles.AssumeLocal, out var result2))
            {
                expiration = result2;
            }
        }
    }


    /// <summary>
    /// Устанавливает значение приватного static readonly поля.
    /// </summary>
    public static void SetPrivateStaticReadonlyField<TDeclaring>(string fieldName, object value)
    {
        var fi = typeof(TDeclaring).GetField(fieldName,
            BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
            ?? throw new MissingFieldException(typeof(TDeclaring).FullName, fieldName);

        if (!fi.IsStatic)
            throw new InvalidOperationException("Поле не static.");

        // DynamicMethod с правами skipVisibility = true
        var dm = new DynamicMethod("__set_" + fieldName, null,
            new[] { typeof(object) }, typeof(TDeclaring), true);

        var il = dm.GetILGenerator();

        // arg0 -> value
        il.Emit(OpCodes.Ldarg_0);
        if (fi.FieldType.IsValueType)
            il.Emit(OpCodes.Unbox_Any, fi.FieldType);
        else
            il.Emit(OpCodes.Castclass, fi.FieldType);

        il.Emit(OpCodes.Stsfld, fi); // записываем в static field
        il.Emit(OpCodes.Ret);

        var setter = (Action<object>)dm.CreateDelegate(typeof(Action<object>));
        setter(value);
    }

    public class ZeekerLicenseProvider : LicenseProvider
    {
        public override License GetLicense(LicenseContext context, System.Type type, object instance, bool allowExceptions)
        => new MyLicense();
    }

    public class MyLicense : License
    {
        public override string LicenseKey => "251,0,0,FULL,1,1,someId->00010101";

        public override void Dispose()
        {
            
        }
    }

}


