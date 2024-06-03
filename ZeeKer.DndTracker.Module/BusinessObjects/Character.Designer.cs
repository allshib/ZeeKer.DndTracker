using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    public partial class Character
    {
        #region Basic
        [XafDisplayName("Имя"), StringLength(150)]
        [RuleRequiredField(DefaultContexts.Save)]
        public virtual string Name { get; set; }

        [XafDisplayName("Уровень")]
        public virtual int Level { get; set; }

        [XafDisplayName("Создано")]
        public virtual DateTimeOffset CreatedAt { get; set; }

        [Browsable(false)]
        public virtual Guid? StatsId { get; set; }

        [XafDisplayName("Характеристики")]
        public virtual CharacterStats? Stats { get; set; }

        [Browsable(false)]
        public virtual Guid? InfoId { get; set; }

        [ForeignKey(nameof(InfoId)), XafDisplayName("Инфо")]
        public virtual CharacterInfo Info { get; set; }

        [Browsable(false)]
        public virtual Guid? ClassId { get; set; }

        [ForeignKey(nameof(ClassId)), XafDisplayName("Класс")]
        public virtual CharacterClass Class { get; set; }

        [Browsable(false)]
        public virtual Guid? RaceId { get; set; }

        [ForeignKey(nameof(RaceId)), XafDisplayName("Раса")]
        public virtual Race Race { get; set; }
        [XafDisplayName("Максимальный вес"), NotMapped]
        public virtual double MaxWeight => (Stats?.Strength?? 1) * 15.0;

        [XafDisplayName("Владение"), Aggregated]
        public virtual IList<AssignedProfiency> Profiencies { get; set; } = new ObservableCollection<AssignedProfiency>();

        [XafDisplayName("Языки"), NotMapped]
        public virtual string Languages => String.Join(", ", Profiencies
            .Where(p=>p.Profiency.GroupProfiencyType == Types.GroupProfiencyType.Languages)
            .Select(x => $"{x.DefaultProperty}"));

        [XafDisplayName("Владение броней"), NotMapped]
        public virtual string ArmorProfiencies => String.Join(", ", Profiencies
            .Where(p => p.Profiency.GroupProfiencyType == Types.GroupProfiencyType.Armors)
            .Select(x => $"{x.DefaultProperty}"));

        [XafDisplayName("Владение оружием"), NotMapped]
        public virtual string WeaponProfiencies => String.Join(", ", Profiencies
            .Where(p => p.Profiency.GroupProfiencyType == Types.GroupProfiencyType.Weapons)
            .Select(x => $"{x.DefaultProperty}"));

        [XafDisplayName("Владение инструментами"), NotMapped]
        public virtual string ToolsProfiencies => String.Join(", ", Profiencies
            .Where(p => p.Profiency.GroupProfiencyType == Types.GroupProfiencyType.Tools)
            .Select(x => $"{x.DefaultProperty}"));

        [XafDisplayName("Максимальное число настроек")]
        public virtual int MaxSettingCount {  get; set; }

        [XafDisplayName("Занято слотов настроек"), NotMapped]
        public virtual int EnabledSettingCount => Storages?
            .Where(s=>s.Local)?
            .FirstOrDefault()?
            .Items
            .Where(i=>i.SettingOnThis)
            .Count()?? 0;

        #endregion

        #region Feats
        [Aggregated, XafDisplayName("Активные черты")]
        public virtual IList<AvailableFeat> AvailableFeats { get; set; } = new ObservableCollection<AvailableFeat>();

        #endregion

        #region Health
        [XafDisplayName("КЗ")]
        public virtual int Armor { get; set; }

        [XafDisplayName("КЗ (calc)"), NotMapped]
        public virtual int ArmorCalc => GetACValue();


        [XafDisplayName("Очки здоровья")]
        public virtual int Health { get; set; }
        [XafDisplayName("Очки здоровья (max)")]
        public virtual int HealthMax { get; set; }

        [XafDisplayName("Очки здоровья (временные)")]
        public virtual int HealthTemp { get; set; }
        [XafDisplayName("Информация о здоровье"), NotMapped]
        public virtual string HealthInfo => $"Здоровье: {Health}/{HealthMax}{(HealthTemp > 0 ? $" + {HealthTemp}" : "")}, КЗ: {ArmorCalc}";
        #endregion

        #region Дополнительно
        [Browsable(false)]
        public virtual Guid? CampainId { get; set; }

        [XafDisplayName("Кампейн")]
        [ForeignKey(nameof(CampainId))]
        [RuleRequiredField(DefaultContexts.Save)]
        public virtual Campain? Campain { get; set; }

        [Browsable(false)]
        public virtual Guid? PersonId { get; set; }


        [ForeignKey(nameof(PersonId))]
        [XafDisplayName("Игрок")]
        [RuleRequiredField(DefaultContexts.Save)]
        public virtual Person? Person { get; set; }

        [XafDisplayName("Блокировка удаления")]
        public virtual bool Block { get; set; }
        #endregion

        #region Storages And Operations

        [Browsable(false)]
        public virtual Guid? ArmorItemId { get; set; }

        [XafDisplayName("Броня"), ForeignKey(nameof(ArmorItemId))]
        public virtual AssignedItem ArmorItem { get; set; }

        [XafDisplayName("Броня (Техническое поле)"), NotMapped]
        public virtual ArmorItem ArmorItemCalc => 
            ArmorItem?.Item is not null ? ArmorItem.Item as ArmorItem : null;

        [Browsable(false)]
        public virtual Guid? ShieldItemId { get; set; }

        [XafDisplayName("Щит"), ForeignKey(nameof(ShieldItemId))]
        public virtual AssignedItem ShieldItem { get; set; }


        [Browsable(false)]
        public virtual Guid? HandRightId { get; set; }

        [XafDisplayName("Правая рука"), ForeignKey(nameof(HandRightId))]
        public virtual AssignedItem HandRight { get; set; }

        [Browsable(false)]
        public virtual Guid? HandLeftId { get; set; }

        [XafDisplayName("Левая рука"), ForeignKey(nameof(HandLeftId))]
        public virtual AssignedItem HandLeft { get; set; }


        [Aggregated]
        [XafDisplayName("Хранилища")]
        public virtual IList<CharacterStorage> Storages { get; set; } = new ObservableCollection<CharacterStorage>();


        [XafDisplayName("Преднастроенные операции"), NotMapped]
        public virtual IEnumerable<MultipleTransaction> MultipleTransaction => new ObservableCollection<MultipleTransaction>(Storages?.SelectMany(storage => storage.MultipleTransactions)) ?? new ObservableCollection<MultipleTransaction>();

        [NotMapped]
        [XafDisplayName("Инвентарь")]
        public CharacterStorage LocalStorage => Storages?.FirstOrDefault(storage => storage.Local);
        #endregion
    }
}
