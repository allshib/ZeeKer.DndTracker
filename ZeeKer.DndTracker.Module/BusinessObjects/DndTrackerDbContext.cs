using Castle.Core.Configuration;
using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.Office;
using DevExpress.Persistent.BaseImpl.EF.StateMachine;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent;

namespace ZeeKer.DndTracker.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class DndTrackerContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<DndTrackerEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new DndTrackerEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class DndTrackerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DndTrackerEFCoreDbContext> {
	public DndTrackerEFCoreDbContext CreateDbContext(string[] args) {
		//throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
		var optionsBuilder = new DbContextOptionsBuilder<DndTrackerEFCoreDbContext>();
        string connectionString = "";
#if !RELEASE
        connectionString = "Integrated Security=SSPI;Pooling=true;MultipleActiveResultSets=true;Data Source=.;Initial Catalog=DndTracker; TrustServerCertificate = True";
#else
        connectionString = "User Id=sa;Password=ZeeKer1218;MultipleActiveResultSets=true;Data Source=192.168.31.253;Initial Catalog=DndTracker; TrustServerCertificate = True";
#endif

        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
		return new DndTrackerEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(DndTrackerContextInitializer))]
public class DndTrackerEFCoreDbContext : DbContext {
	public DndTrackerEFCoreDbContext(DbContextOptions<DndTrackerEFCoreDbContext> options) : base(options) {
	}
	public DbSet<ModuleInfo> ModulesInfo { get; set; }
	public DbSet<ModelDifference> ModelDifferences { get; set; }
	public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
	public DbSet<PermissionPolicyRole> Roles { get; set; }
	public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationUserLoginInfo> UserLoginInfos { get; set; }
	public DbSet<FileData> FileData { get; set; }
	public DbSet<ReportDataV2> ReportDataV2 { get; set; }
    public DbSet<StateMachine> StateMachines { get; set; }
    public DbSet<StateMachineState> StateMachineStates { get; set; }
    public DbSet<StateMachineTransition> StateMachineTransitions { get; set; }
    public DbSet<StateMachineAppearance> StateMachineAppearances { get; set; }
	public DbSet<DashboardData> DashboardData { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<Campain> Campains { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<CharacterStorage> CharacterStorages { get; set; }
    public DbSet<StorageOperation> StorageOperations { get; set; }
    public DbSet<CharacterClass> CharacterClasses { get; set; }

    public DbSet<Skills> Skills { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ArmorItem> ArmorItems { get; set; }
    public DbSet<ShieldItem> ShieldItems { get; set; }
    public DbSet<WeaponItem> WeaponItems { get; set; }

    public DbSet<AssignedItem> AssignedItems { get; set; }

    public DbSet<SimpleItem> SimpleItems { get; set; }
    public DbSet<Profiency> Profiencies { get; set; }
    public DbSet<AssignedProfiency> AssignedProfiencies { get; set; }
    public DbSet<Feat> Feats { get; set; }
    public DbSet<BonusBase> Bonuses { get; set; }
    public DbSet<StatBonus> StatBonuses { get; set; }
    public DbSet<AssignedFeatBonus> AssignedFeatBonuses { get; set; }
    public DbSet<StatBonusGroup> StatBonusGroups { get; set; }
    public DbSet<OneStatBonus> OneStatBonuses { get; set; }
    public DbSet<AvailableFeat> AvailableFeats { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        
        builder.ConfigureWarnings(delegate (WarningsConfigurationBuilder warnings)
        {
            // The following line will suppress the warning
            // "'Foo.Bar' and 'Bar.Foo' were separated into two relationships as
            // ForeignKeyAttribute was specified on properties 'BarId' and
            // 'FooId' on both sides."
            warnings.Ignore(CoreEventId.ForeignKeyAttributesOnBothNavigationsWarning);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
        modelBuilder.Entity<ApplicationUserLoginInfo>(b => {
            b.HasIndex(nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.LoginProviderName), nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.ProviderUserKey)).IsUnique();
        });
        modelBuilder.Entity<StateMachine>()
            .HasMany(t => t.States)
            .WithOne(t => t.StateMachine)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ModelDifference>()
            .HasMany(t => t.Aspects)
            .WithOne(t => t.Owner)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Character>()
            .HasOne(t=>t.Person)
            .WithMany(t=>t.Characters)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(t => t.Person)
            .WithOne(t => t.User)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Person>()
            .HasOne(t => t.User)
            .WithOne(t => t.Person)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<StorageOperation>()
            .HasOne(op => op.Storage)
            .WithMany(storage => storage.Operations);
        //.OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<StorageOperation>()
            .HasOne(op => op.StorageSource)
            .WithMany(storage => storage.OperationsFromThis);
            //.OnDelete(DeleteBehavior.SetNull);

        //modelBuilder.Entity<CharacterStorage>()
        //    .HasMany(st=>st.MultipleTransactions)
        //    .WithOne(tr=>tr.StorageSource)
        //    .OnDelete(DeleteBehavior.SetNull);

        //modelBuilder.Entity<MultipleTransaction>()
        //    .HasMany(st => st.TransactionSettings)
        //    .WithOne(tr => tr.Transaction)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<MultipleTransaction>()
        //    .HasMany(st => st.StorageOperations)
        //    .WithOne(tr => tr.MultipleTransaction)
        //    .OnDelete(DeleteBehavior.SetNull);



        modelBuilder.Entity<Character>()
            .HasOne(ch => ch.Class)
            .WithMany(ch => ch.Characters)
            .OnDelete(DeleteBehavior.SetNull);

        
        modelBuilder.Entity<CharacterStats>()
            .HasOne(st=> st.Character)
            .WithOne(st=> st.Stats)
            .HasForeignKey<CharacterStats>(a => a.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasMany(ch => ch.Storages)
            .WithOne(st => st.Character)
            .OnDelete(DeleteBehavior.SetNull);




        modelBuilder.Entity<SkillDetail>()
            .HasOne(x => x.Skills)
            .WithMany(x => x.SkillDetails)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Skills>()
            .HasOne(skills=>skills.Stats)
            .WithOne(st => st.Skills)
            .HasForeignKey<Skills>(a => a.StatsId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(ch => ch.Race)
            .WithMany(race => race.Characters)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Item>()
            .HasMany(item => item.AssignedItems)
            .WithOne(ass=>ass.Item)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<CharacterStorage>()
            .HasMany(st=>st.Items)
            .WithOne(ass=>ass.Storage)
            .OnDelete(DeleteBehavior.SetNull);
            
        modelBuilder.Entity<Character>()
            .HasMany(ch=>ch.Profiencies)
            .WithOne(ch=>ch.Character)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Profiency>()
            .HasMany(p=>p.Items)
            .WithOne(i=>i.Profiency)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Feat>()
            .HasMany(f => f.Bonuses)
            .WithOne(ab => ab.Feat)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StatBonus>()
            .HasMany(sb => sb.BonusGroups)
            .WithOne(g => g.Bonus)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StatBonusGroup>()
            .HasMany(g => g.StatBonuses)
            .WithOne(sb => sb.Group)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasMany(g => g.AvailableFeats)
            .WithOne(sb => sb.Character)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AvailableFeat>()
            .Property(f=>f.SelectedBonuses)
            .HasConversion(
                v => JsonSerializer
                    .Serialize(v, new JsonSerializerOptions
                        { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
                v => JsonSerializer
                    .Deserialize<AvailableFeatJson>(v, new JsonSerializerOptions
                        { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull })
            );

        base.OnModelCreating(modelBuilder);
    }


    
}
