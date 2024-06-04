using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Extensions;

namespace ZeeKer.DndTracker.Module.UseCases.SelectFeatUseCase
{
    [DomainComponent]
    public class SelectFeatViewModel : IXafEntityObject, INotifyPropertyChanged, IObjectSpaceLink
    {
        private IObjectSpace objectSpace;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SelectFeatViewModel()
        {
            Oid = Guid.NewGuid();
        }

        

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]
        public Guid Oid { get; set; }

        private Feat feat;
        [XafDisplayName("Черта")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Feat Feat
        {
            get { return feat; }
            set
            {
                if (feat != value)
                {
                    feat = value;
                    OnPropertyChanged();
                }
            }
        }

        //[XafDisplayName("Описание")]
        //public string Description => Feat?.Description;


        public IEnumerable<Feat> Feats { get; set; }

        public List<StatSelectObject> StatSelectObjects { get; set; } = new List<StatSelectObject>();


        [XafDisplayName("Бонус характеристик")]
        public StatBonus StatBonus => Feat is not null && Feat.Bonuses.Any(x=>x.Bonus?.Type == Types.BonusType.Stat)
            ? Feat.Bonuses.Select(b=>b.Bonus).FirstOrDefault(x=>x.Type == Types.BonusType.Stat) as StatBonus
            : null;


        private StatBonusGroup statBonusGroup;
        [XafDisplayName("Группа бонусов характеристик")]
        public  StatBonusGroup StattBonusGroup
        {
            get { return statBonusGroup; }
            set
            {
                if (statBonusGroup != value)
                {
                    statBonusGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        [XafDisplayName("Список групп характеристик")]
        public IEnumerable<StatBonusGroup> GroupsList => StatBonus?.BonusGroups;
        #region IXafEntityObject
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.
        }
        #endregion

        #region IObjectSpaceLink members
       
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}