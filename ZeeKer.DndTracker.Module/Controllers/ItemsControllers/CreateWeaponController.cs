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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.UseCases.CreateWeaponUseCase;
using ZeeKer.DndTracker.Module.UseCases.LoadItemsUseCase;

namespace ZeeKer.DndTracker.Module.Controllers.ItemsControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CreateWeaponController : ViewController
    {
        SingleChoiceAction actionMelee;
        SingleChoiceAction actionMeleeWarrior;
        SingleChoiceAction actionRange;
        SingleChoiceAction actionWarriorRange;
        private ICreateWeaponUseCase useCase;

        public CreateWeaponController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Item);
            TargetViewType = ViewType.ListView;
            actionMelee = new SingleChoiceAction(this, "CreateWeapon", PredefinedCategory.Unspecified)
            {
                Caption = "Создать рукопашное оружие",
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
            useCase.Execute(new CreateWeaponCommand(e.SelectedChoiceActionItem.Data as string));
        }

        private void ActionRange_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            useCase.Execute(new CreateWeaponCommand(e.SelectedChoiceActionItem.Data as string));
        }

        private void ActionWarrior_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            useCase.Execute(new CreateWeaponCommand(e.SelectedChoiceActionItem.Data as string));
        }

        private void ActionMelee_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            useCase.Execute(new CreateWeaponCommand(e.SelectedChoiceActionItem.Data as string));
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            useCase = new CreateWeaponUseCase(Application);

            actionMelee.Items.Add(new ChoiceActionItem("Создать боевой посох", "Quarterstaff"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать булаву", "Mace"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать дубинку", "Club"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать кинжал", "Dagger"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать копьё", "Spear"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать лёгкий молот", "LightHammer"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать метательное копьё", "Javelin"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать палицу", "Greatclub"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать ручной топор", "Handaxe"));
            actionMelee.Items.Add(new ChoiceActionItem("Создать серп", "Sickle"));



            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать алебарду", "Halberd"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать боевую кирку", "WarPick"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать боевой молот", "Warhammer"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать боевой топор", "Battleaxe"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать глефу", "Glaive"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать двуручный меч", "Greatsword"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать длинное копьё", "Pike"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать длинный меч", "Longsword"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать кнут", "Whip"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать короткий меч", "Shortsword"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать молот", "Maul"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать моргенштерн", "Morningstar"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать пику", "Pike"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать рапиру", "Rapier"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать секиру", "Greataxe"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать скимитар", "Scimitar"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать трезубец", "Trident"));
            actionMeleeWarrior.Items.Add(new ChoiceActionItem("Создать цеп", "Flail"));



            actionRange.Items.Add(new ChoiceActionItem("Создать лёгкий арбалет", "LightCrossbow"));
            actionRange.Items.Add(new ChoiceActionItem("Создать дротик", "Dart"));
            actionRange.Items.Add(new ChoiceActionItem("Создать короткий лук", "Shortbow"));
            actionRange.Items.Add(new ChoiceActionItem("Создать пращу", "Sling"));



            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать ручной арбалет", "HandCrossbow"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать тяжёлый арбалет", "HeavyCrossbow"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать длинный лук", "Longbow"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать духовую трубку", "Blowgun"));
            actionWarriorRange.Items.Add(new ChoiceActionItem("Создать сеть", "Net"));
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
