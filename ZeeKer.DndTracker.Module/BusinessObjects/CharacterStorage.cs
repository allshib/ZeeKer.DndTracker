using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeeKer.DndTracker.Module.BusinessObjects;
    [DefaultClassOptions]
    [XafDisplayName("���������")]
    [XafDefaultProperty(nameof(DefaultProperty))]
    public class CharacterStorage : BaseObject
    {
        public CharacterStorage()
        {
        }

        #region Fields
        [XafDisplayName("���������")]
        public string DefaultProperty => $"{Character?.Name} {Name}: {CoinsInfo}";

        [XafDisplayName("������������"), StringLength(150)]
        public virtual string Name { get; set; }

        [XafDisplayName("��������"), StringLength(750)]
        public virtual string Description { get; set; }


        [XafDisplayName("������ ������")]
        public virtual decimal CopperCoins { get; set; }

        [XafDisplayName("����������� ������")]
        public decimal SilverCoins => CopperCoins / 10;
        [XafDisplayName("������� ������")]
        public decimal GoldCoins => CopperCoins / 100;
        [XafDisplayName("���������� ������")]
        public decimal PlatinumCoins => CopperCoins / 1000;

        [XafDisplayName("������")]
        public string CoinsInfo =>
            $"{TruncateCoins(GoldCoins, "��", true)}{TruncateCoins((CopperCoins % 100)/10, "��", true)}{TruncateCoins(CopperCoins % 10, "��")}";


        [XafDisplayName("��������� ���������")]
        public virtual bool Local { get; set; }

        [Browsable(false)]
        public virtual Guid? CharacterId { get; set; }


        [ForeignKey(nameof(CharacterId))]
        [XafDisplayName("��������")]
        public virtual Character? Character { get; set; }


        [Aggregated]
        [XafDisplayName("������� ��������/��������")]
        public virtual IList<StorageOperation> Operations { get; set; } = new ObservableCollection<StorageOperation>();

        [Aggregated]
        [XafDisplayName("��������� ��������")]
        public virtual IList<StorageOperation> OperationsFromThis { get; set; } = new ObservableCollection<StorageOperation>();

        

        #endregion

        private string TruncateCoins(decimal coins, string nominal, bool addZapit = false) =>
            coins >= 1
                ? $"{Math.Truncate(coins)}{nominal}{(addZapit && Math.Truncate(coins) != coins ? ", " : "")}"
                : "";
    }
