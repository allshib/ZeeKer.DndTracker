using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using ZeeKer.DndTracker.Module.BusinessObjects;
using Microsoft.Extensions.DependencyInjection;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.DatabaseUpdate;


public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseBeforeUpdateSchema()
    {
        base.UpdateDatabaseBeforeUpdateSchema();
    }

    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();

        if (CurrentDBVersion < new Version("0.2.1"))
        {
            CreateDefaulUsers();
            CreateDefaultEntities();
        }

        if (CurrentDBVersion < new Version("0.2.4"))
            CreateDefaultClasses();

        if (CurrentDBVersion < new Version("0.2.5"))
        {
            CreateEmptyCompain();
            SetCreatedAtDateForCharacter();
        }


        if (CurrentDBVersion < new Version("0.2.6"))
        {
            FillSkills();
        }
    }

    private void FillSkills()
    {
        var stats = ObjectSpace.GetObjects<CharacterStats>(CriteriaOperator.Parse($"{nameof(CharacterStats.SkillsId)} = ?", null));
        foreach (var stat in stats)
        {
            stat.Skills = ObjectSpace.CreateObject<BusinessObjects.Skills>();
        }
        ObjectSpace.CommitChanges();
    }

    private void SetCreatedAtDateForCharacter()
    {
        var characters = ObjectSpace.GetObjects<Character>();
        foreach (Character character in characters)
        {
            character.CreatedAt = DateTimeOffset.Now;
        }
        ObjectSpace.CommitChanges();
    }

    private void CreateEmptyCompain()
    {
        var emptyCompain = ObjectSpace.CreateObject<Campain>();
        emptyCompain.Name = "Пустой";
        ObjectSpace.CommitChanges();
    }

    private void CreateDefaultClasses()
    {
        CreateClass("Бард", CharacterClassType.Bard, DiceRollType.K8);
        CreateClass("Варвар", CharacterClassType.Barbarian, DiceRollType.K12);
        CreateClass("Воин", CharacterClassType.Fighter, DiceRollType.K10);
        CreateClass("Волшебник", CharacterClassType.Wizard, DiceRollType.K6);
        CreateClass("Друид", CharacterClassType.Druid, DiceRollType.K8);
        CreateClass("Жрец", CharacterClassType.Cleric, DiceRollType.K8);
        CreateClass("Изобретатель", CharacterClassType.Artificer, DiceRollType.K8);
        CreateClass("Колдун", CharacterClassType.Warlock, DiceRollType.K8);
        CreateClass("Монах", CharacterClassType.Monk, DiceRollType.K8);
        CreateClass("Паладин", CharacterClassType.Paladin, DiceRollType.K10);
        CreateClass("Плут", CharacterClassType.Rogue, DiceRollType.K8);
        CreateClass("Следопыт", CharacterClassType.Ranger, DiceRollType.K10);
        CreateClass("Чародей", CharacterClassType.Sorcerer, DiceRollType.K6);
        ObjectSpace.CommitChanges();
    }


    private void CreateClass(string name, CharacterClassType type, DiceRollType helthDice)
    {
        var characterClass = ObjectSpace.CreateObject<CharacterClass>();

        characterClass.Name = name;
        characterClass.ClassType = type;
        characterClass.HealthDice = helthDice;
    }

    private void CreateDefaulUsers()
    {
        var defaultRole = CreateDefaultRole();
        var adminRole = CreateAdminRole();

        ObjectSpace.CommitChanges();

        UserManager userManager = ObjectSpace.ServiceProvider.GetRequiredService<UserManager>();

        if (userManager.FindUserByName<ApplicationUser>(ObjectSpace, "User") == null)
        {

            string EmptyPassword = "";
            var userResult = userManager.CreateUser<ApplicationUser>(ObjectSpace, "User", EmptyPassword, (user) => {
                // Add the Users role to the user
                user.Roles.Add(defaultRole);
            });


        }

        if (userManager.FindUserByName<ApplicationUser>(ObjectSpace, "Admin") == null)
        {

            string EmptyPassword = "";
            var userResult = userManager.CreateUser<ApplicationUser>(ObjectSpace, "Admin", EmptyPassword, (user) => {

                user.Roles.Add(adminRole);
            });

        }
        ObjectSpace.CommitChanges(); //This line persists created object(s).
        ObjectSpace.Refresh();
    }


    private void CreateDefaultEntities()
    {
        var campain = ObjectSpace.CreateObject<Campain>();
        campain.Name = "И солнце закатилось";
        ObjectSpace.CommitChanges();

        var campain2 = ObjectSpace.CreateObject<Campain>();
        campain2.Name = "Тестовый кампейн";
        ObjectSpace.CommitChanges();


        var character = ObjectSpace.CreateObject<Character>();
        character.Name = "Рей Аянами";
        character.Campain = campain;

        ObjectSpace.CommitChanges();


        campain.GameMaster = character.Person;
        var character2 = ObjectSpace.CreateObject<Character>();
        character2.Name = "Алина";
        character2.Campain = campain;
        ObjectSpace.CommitChanges();


        var character3 = ObjectSpace.CreateObject<Character>();
        character3.Name = "Тестовый персонаж";
        character3.Campain = campain2;
        ObjectSpace.CommitChanges();

        var character4 = ObjectSpace.CreateObject<Character>();
        character4.Name = "Гунвард";
        character4.Campain = campain;
        ObjectSpace.CommitChanges();
    }
    private PermissionPolicyRole CreateAdminRole() {
        PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Administrators");
        if(adminRole == null) {
            adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
            adminRole.Name = "Administrators";
            adminRole.IsAdministrative = true;
        }
        return adminRole;
    }
    private PermissionPolicyRole CreateDefaultRole() {
        PermissionPolicyRole defaultRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(role => role.Name == "Default");
        if(defaultRole == null) {
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
