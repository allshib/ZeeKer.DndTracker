using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Controllers.ItemsControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CreateWeaponController : ViewController
    {
        SingleChoiceAction actionMelee;
        SingleChoiceAction actionMeleeWarrior;
        SingleChoiceAction actionRange;
        SingleChoiceAction actionWarriorRange;
        public CreateWeaponController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Item);
            TargetViewType = ViewType.ListView;
            actionMelee = new SingleChoiceAction(this, "CreateWeapon", PredefinedCategory.Unspecified)
            {
                Caption = "Создать рукопашное оружие"
            };

            actionMelee.Execute += ActionMelee_Execute;

            actionMeleeWarrior = new SingleChoiceAction(this, "CreateWarriorWeapon", PredefinedCategory.Unspecified)
            {
                Caption = "Создать воинское рукопашное оружие"
            };

            actionMeleeWarrior.Execute += ActionWarrior_Execute;


            actionRange = new SingleChoiceAction(this, "CreateRangeWeapon", PredefinedCategory.Unspecified)
            {
                Caption = "Создать дальнобольнее оружие"
            };

            actionRange.Execute += ActionRange_Execute;


            actionWarriorRange = new SingleChoiceAction(this, "CreateWarriorRangeWeapon", PredefinedCategory.Unspecified)
            {
                Caption = "Создать воинское дальнобольнее оружие"
            };

            actionWarriorRange.Execute += ActionWarriorRange_Execute;
        }

        private void ActionWarriorRange_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ActionRange_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ActionWarrior_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ActionMelee_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            actionMelee.Items.Add(new ChoiceActionItem("Создать боевой посох", "CreateQuarterstaff"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать булаву", "CreateMace"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать дубинку", "CreateClub"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать кинжал", "CreateDagger"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать копьё", "CreateSpear"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать лёгкий молот", "CreateLightHammer"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать метательное копьё", "CreateJavelin"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать палицу", "CreateGreatclub"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать ручной топор", "CreateHandaxe"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать серп", "CreateSickle"));



            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать алебарду", "CreateHalberd"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать боевую кирку", "CreateWarPick"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать боевой молот", "CreateWarhammer"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать боевой топор", "CreateBattleaxe"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать глефу", "CreateGlaive"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать двуручный меч", "CreateGreatsword"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать длинное копьё", "CreatePike"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать длинный меч", "CreateLongsword"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать кнут", "CreateWhip"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать короткий меч", "CreateShortsword"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать молот", "CreateMaul"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать моргенштерн", "CreateMorningstar"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать пику", "CreatePike"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать рапиру", "CreateRapier"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать секиру", "CreateGreataxe"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать скимитар", "CreateScimitar"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать трезубец", "CreateTrident"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать цеп", "CreateFlail"));



            actionRange.Items.Add(new ChoiceActionItem("Создать лёгкий арбалет", "CreateLightCrossbow"));
            actionRange.Items.Add(new ChoiceActionItem("Создать дротик", "CreateDart"));
            actionRange.Items.Add(new ChoiceActionItem("Создать короткий лук", "CreateShortbow"));
            actionRange.Items.Add(new ChoiceActionItem("Создать пращу", "CreateSling"));



            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать ручной арбалет", "CreateHandCrossbow"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать тяжёлый арбалет", "CreateHeavyCrossbow"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать длинный лук", "CreateLongbow"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать духовую трубку", "CreateBlowgun"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать сеть", "CreateNet"));
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
