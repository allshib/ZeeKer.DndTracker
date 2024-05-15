using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    [XafDisplayName("Класс персонажа")]
    [XafDefaultProperty(nameof(Name))]
    public class CharacterClass : BaseObject
    {
        public CharacterClass()
        {
            
        }

        [XafDisplayName("Название")]
        public virtual string Name { get; set; }

        [XafDisplayName("Кость хитов")]
        public virtual DiceRollType HealthDice { get; set; }

        [XafDisplayName("Тип")]
        public virtual CharacterClassType ClassType { get; set; }


        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}