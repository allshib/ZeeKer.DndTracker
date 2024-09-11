using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using Riok.Mapperly.Abstractions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeeKer.DndTracker.Module.UseCases.OpenDocumentationUseCase;

namespace ZeeKer.DndTracker.Module.BusinessObjects;
    [DefaultClassOptions]
    [XafDisplayName("Хранилище")]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public class CharacterStorage : BaseObject, IOpenDoc
    {
        public CharacterStorage()
        {
        }

        [XafDisplayName("Предметы"), Aggregated, MapperIgnore]
        public virtual IList<AssignedItem> Items { get; set; } = new ObservableCollection<AssignedItem>();

        #region Fields
        [XafDisplayName("Хранилище"), MapperIgnore]
        public string DefaultProperty => $"{Character?.Name} {Name}: {CoinsInfo}";

        [XafDisplayName("Наименование"), StringLength(150)]
        public virtual string Name { get; set; }

        [XafDisplayName("Описание"), StringLength(750)]
        public virtual string Description { get; set; }


        [XafDisplayName("Быстрые операции")]
        public virtual bool FastOperations { get; set; }

    [XafDisplayName("Медные монеты")]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal CopperCoins { get; set; }

        [XafDisplayName("Серебрянные монеты"), MapperIgnore]
        public decimal SilverCoins => CopperCoins / 10;
        [XafDisplayName("Золотые монеты")]
        public decimal GoldCoins => CopperCoins / 100;
        [XafDisplayName("Платиновые монеты"),MapperIgnore]
        public decimal PlatinumCoins => CopperCoins / 1000;

        [XafDisplayName("Деньги"), MapperIgnore]
        public string CoinsInfo =>
            $"{TruncateCoins(GoldCoins, "зм", true)}{TruncateCoins((CopperCoins % 100)/10, "см", true)}{TruncateCoins(CopperCoins % 10, "мм")}";


        [XafDisplayName("Инвентарь персонажа")]
        public virtual bool Local { get; set; }

        [Browsable(false), MapperIgnore]
        public virtual Guid? CharacterId { get; set; }


        [ForeignKey(nameof(CharacterId)), MapperIgnore]
        [XafDisplayName("Персонаж")]
        public virtual Character? Character { get; set; }


        [Aggregated]
        [XafDisplayName("Простые Операции/Входящие"), MapperIgnore]
        public virtual IList<StorageOperation> Operations { get; set; } = new ObservableCollection<StorageOperation>();

        [Aggregated]
        [XafDisplayName("Исходящие Операции"), MapperIgnore]
        public virtual IList<StorageOperation> OperationsFromThis { get; set; } = new ObservableCollection<StorageOperation>();
        [XafDisplayName("Настройки мульти-транзакций"), Aggregated, MapperIgnore]
        public virtual IList<MultipleTransaction> MultipleTransactions { get; set; } = new ObservableCollection<MultipleTransaction>();

    [XafDisplayName("Предметы (строка)"), NotMapped, MapperIgnore]
    public virtual string ItemsString => String.Join(", ", Items.Select(x => $"{x.Item?.Name} {x.Count}шт"));
        #endregion

        private string TruncateCoins(decimal coins, string nominal, bool addZapit = false) =>
            coins >= 1
                ? $"{Math.Truncate(coins)}{nominal}{(addZapit && Math.Truncate(coins) != coins ? ", " : "")}"
                : "";
    }
