using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.EFCore;
using Microsoft.EntityFrameworkCore;
using ZeeKer.DndTracker.Module.BusinessObjects;
using Microsoft.Extensions.Options;
using ZeeKer.DndTracker.Module;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.Data.Filtering;

namespace Zeeker.DndTracker.Tests.Mock
{
    public class MockCreateSimpleCommand
    {

        private readonly IObjectSpace objectSpace;
        private static TestApplication application;



        public IObjectSpace ObjectSpace
        {
            get
            {
                return objectSpace;
            }
        }

        public static TestApplication Application
        {
            get
            {
                return application;
            }
        }

        /// <summary>
        /// Инициализация модулей системы для подключения токенов и API при выполнении тестов
        /// </summary>
        public MockCreateSimpleCommand()
        {
            var t = new DbContextOptionsBuilder<DndTrackerEFCoreDbContext>();
            t.UseInMemoryDatabase("Test");


            var objectSpaceProvider =
                new EFCoreObjectSpaceProvider<DndTrackerEFCoreDbContext>((options, connectionString) => {
                    options.UseInMemoryDatabase("Test");
                    connectionString = "Test";
                    options.UseChangeTrackingProxies();
                    options.UseObjectSpaceLinkProxies();
                    options.UseLazyLoadingProxies();
                });


            application = new TestApplication();


            //XafTypesInfo.Instance.RegisterEntity(typeof(PayrollRules));
            //XafTypesInfo.Instance.RegisterEntity(typeof(Payroll));

            //XafTypesInfo.Instance.GenerateEntities();

            var mainModule = new DndTrackerModule();
            Application.Modules.Add(mainModule);

            Application.Setup("TestApplication", objectSpaceProvider);

            objectSpace = objectSpaceProvider.CreateObjectSpace();



            CreateDefaulUsers();

            var user = ObjectSpace.FindObject<ApplicationUser>(CriteriaOperator.FromLambda<ApplicationUser>(x => x.UserName == "Admin"));

            var auth = new AuthenticationStandard();
            auth.SetLogonParameters(new AuthenticationStandardLogonParameters(user.UserName, ""));
            var security =
                new SecurityStrategyComplex(typeof(ApplicationUser), typeof(PermissionPolicyRole), auth);
            SecuritySystem.SetInstance((ISecurityStrategyBase)security);
            //security.Logon(objectSpace);


            
            
            objectSpace.CommitChanges();
        }


        private void CreateDefaulUsers()
        {
            var defaultRole = CreateDefaultRole();
            var adminRole = CreateAdminRole();

            ObjectSpace.CommitChanges();

            //UserManager userManager = ObjectSpace.ServiceProvider.GetRequiredService<UserManager>();


            string EmptyPassword = "";
            var userResult = ObjectSpace.CreateObject<ApplicationUser>();
            userResult.UserName = "Admin";
            userResult.SetPassword("");
            userResult.Roles.Add(adminRole);
            
            
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            ObjectSpace.Refresh();
        }


        private PermissionPolicyRole CreateAdminRole()
        {
            PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Administrators");
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
                adminRole.IsAdministrative = true;
            }
            return adminRole;
        }

        private PermissionPolicyRole CreateDefaultRole()
        {
            PermissionPolicyRole defaultRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(role => role.Name == "Default");
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectPermissionFromLambda<ApplicationUser>(SecurityOperations.Read, cm => cm.ID == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
                defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", cm => cm.ID == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "StoredPassword", cm => cm.ID == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                defaultRole.AddObjectPermission<ModelDifference>(SecurityOperations.ReadWriteAccess, "UserId = ToStr(CurrentUserId())", SecurityPermissionState.Allow);
                defaultRole.AddObjectPermission<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, "Owner.UserId = ToStr(CurrentUserId())", SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);
            }
            return defaultRole;
        }
    }
}
