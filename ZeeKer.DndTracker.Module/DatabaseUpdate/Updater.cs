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

        if (CurrentDBVersion < new Version("0.2.8"))
        {
            UpdateHealth();
        }

        if (CurrentDBVersion < new Version("0.2.9"))
        {
            CreateDefaultRaces();
        }

        if (CurrentDBVersion < new Version("0.3.1"))
        {
            SetMaxSettingCount();
        }

        if (CurrentDBVersion < new Version("0.3.2"))
        {
            FixArmorType();
        }


        if (CurrentDBVersion < new Version("0.3.7"))
        {
            AddSourceToClasses();
        }

        if (CurrentDBVersion < new Version("0.3.7.1"))
        {
            AddSourceToRace();
        }
    }

    private void AddSourceToRace()
    {
        var races = ObjectSpace.GetObjects<ZeeKer.DndTracker.Module.BusinessObjects.Race>();
        foreach (var c in races)
        {
            c.Source = SourceType.PHB;
        }
        ObjectSpace.CommitChanges();
    }

    private void AddSourceToClasses()
    {
        var classes = ObjectSpace.GetObjects<CharacterClass>();
        foreach (var c in classes)
        {
            c.Source = SourceType.PHB;
        }
        ObjectSpace.CommitChanges();
    }

    private void FixArmorType()
    {
        var armors = ObjectSpace.GetObjects<ArmorItem>();
        
        foreach(ArmorItem armor in armors)
        {
            switch (armor.ArmorType)
            {
                case ArmorType.Cloth:
                    armor.ArmorType = ArmorType.Light;
                    break;
                case ArmorType.Light:
                    armor.ArmorType = ArmorType.Medium;
                    break;
                case ArmorType.Medium:
                    armor.ArmorType = ArmorType.Heavy;
                    break;
            }
        }
        ObjectSpace.CommitChanges();
    }

    private void SetMaxSettingCount()
    {
        var characters = ObjectSpace.GetObjects<Character>();
        foreach (Character character in characters)
        {
            character.MaxSettingCount = 3;
        }
        ObjectSpace.CommitChanges();
    }

    private void CreateDefaultRaces()
    {
        CreateRace("Ааракокра", RaceType.Aarakocra);
        CreateRace("Аасимар", RaceType.Aasimar);
        CreateRace("Автогном", RaceType.Autognome);
        CreateRace("Астральный эльф", RaceType.AstralElf);
        CreateRace("Багбир", RaceType.Bugbear);
        CreateRace("Ведалкен", RaceType.Vedalken);
        CreateRace("Вердан", RaceType.Verdan);
        CreateRace("Симик-гибрид", RaceType.SimicHybrid);
        CreateRace("Гит", RaceType.Gith);
        CreateRace("Гифф", RaceType.Giff);
        CreateRace("Гном", RaceType.Gnome);
        CreateRace("Гоблин", RaceType.Goblin);
        CreateRace("Голиаф", RaceType.Goliath);
        CreateRace("Грюн", RaceType.Grung);
        CreateRace("Дварф", RaceType.Dwarf);
        CreateRace("Генази", RaceType.Genasi);
        CreateRace("Драконорожденный", RaceType.Dragonborn);
        CreateRace("Харенгон", RaceType.Harengon);
        CreateRace("Калаштар", RaceType.Kalashtar);
        CreateRace("Кендер", RaceType.Kender);
        CreateRace("Кенку", RaceType.Kenku);
        CreateRace("Кентавр", RaceType.Centaur);
        CreateRace("Кобольд", RaceType.Kobold);
        CreateRace("Варфорджд", RaceType.Warforged);
        CreateRace("Леонин", RaceType.Leonin);
        CreateRace("Локатан", RaceType.Locathan);
        CreateRace("Локсодон", RaceType.Loxondon);
        CreateRace("Ящеролюд", RaceType.Lizardfolk);
        CreateRace("Минотавр", RaceType.Minotaur);
        CreateRace("Орк", RaceType.Orc);
        CreateRace("Плазмоид", RaceType.Plazmoid);
        CreateRace("Полуорк", RaceType.HalfOrc);
        CreateRace("Полурослик", RaceType.Halfling);
        CreateRace("Полуэльф", RaceType.HalfElf);
        CreateRace("Сатир", RaceType.Satyr);
        CreateRace("Оулин", RaceType.Owlin);
        CreateRace("Табакси", RaceType.Tabaxi);
        CreateRace("Тифлинг", RaceType.Tiefling);
        CreateRace("Тортль", RaceType.Tortle);
        CreateRace("Три-Крин", RaceType.ThriKreen);
        CreateRace("Тритон", RaceType.Triton);
        CreateRace("Фирболг", RaceType.Firbolg);
        CreateRace("Фея", RaceType.Fairy);
        CreateRace("Хадози", RaceType.Hadozee);
        CreateRace("Хобгоблин", RaceType.Hobgoblin);
        CreateRace("Оборотень", RaceType.Changeling);
        CreateRace("Человек", RaceType.Human);
        CreateRace("Шифт", RaceType.Shifter);
        CreateRace("Эльф", RaceType.Elf);
        CreateRace("Юань-ти чистокровный", RaceType.YuantiPureblood);
        ObjectSpace.CommitChanges();
    }

    private void CreateRace(string name, RaceType raceType)
    {
        var race = ObjectSpace.CreateObject<BusinessObjects.Race>();
        race.Name = name;
        race.RaceType = raceType;
    }

    private void UpdateHealth()
    {
        var characters = ObjectSpace.GetObjects<Character>();

        foreach (Character character in characters)
        {
            character.HealthMax = character.Health;
        }
        ObjectSpace.CommitChanges();
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
        CreateClass("Бард", CharacterClassType.Bard, DiceHitType.D8);
        CreateClass("Варвар", CharacterClassType.Barbarian, DiceHitType.D12);
        CreateClass("Воин", CharacterClassType.Fighter, DiceHitType.D10);
        CreateClass("Волшебник", CharacterClassType.Wizard, DiceHitType.D6);
        CreateClass("Друид", CharacterClassType.Druid, DiceHitType.D8);
        CreateClass("Жрец", CharacterClassType.Cleric, DiceHitType.D8);
        CreateClass("Изобретатель", CharacterClassType.Artificer, DiceHitType.D8);
        CreateClass("Колдун", CharacterClassType.Warlock, DiceHitType.D8);
        CreateClass("Монах", CharacterClassType.Monk, DiceHitType.D8);
        CreateClass("Паладин", CharacterClassType.Paladin, DiceHitType.D10);
        CreateClass("Плут", CharacterClassType.Rogue, DiceHitType.D8);
        CreateClass("Следопыт", CharacterClassType.Ranger, DiceHitType.D10);
        CreateClass("Чародей", CharacterClassType.Sorcerer, DiceHitType.D6);
        ObjectSpace.CommitChanges();
    }


    private void CreateClass(string name, CharacterClassType type, DiceHitType helthDice)
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
