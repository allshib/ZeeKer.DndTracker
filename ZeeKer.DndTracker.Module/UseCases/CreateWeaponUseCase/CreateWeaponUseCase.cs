using DevExpress.ExpressApp;
using System;
using ZeeKer.DndTracker.Module.BusinessObjects;
using ZeeKer.DndTracker.Module.Types;

namespace ZeeKer.DndTracker.Module.UseCases.CreateWeaponUseCase
{
    internal class CreateWeaponUseCase : ShowViewUseCaseBase, ICreateWeaponUseCase
    {
        public CreateWeaponUseCase(XafApplication application) : base(application)
        {
        }

        public void Execute(CreateWeaponCommand command)
        {
            var objectSpace = application.CreateObjectSpace(typeof(WeaponItem));
            var weaponType = command.weaponType;

            var weapon = objectSpace.CreateObject<WeaponItem>();
            weapon.Rarity = ItemRarityType.Common;
            
            switch (weaponType)
            {
                // Простое рукопашное оружие
                case "Quarterstaff":
                    weapon.Name = "Боевой посох";
                    weapon.Damage = "1к6 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.Universal;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 4;
                    break;

                case "Mace":
                    weapon.Name = "Булава";
                    weapon.Damage = "1к6 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 4;
                    break;

                case "Club":
                    weapon.Name = "Дубинка";
                    weapon.Damage = "1к4 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    break;

                case "Dagger":
                    weapon.Name = "Кинжал";
                    weapon.Damage = "1к4 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 1;
                    weapon.Throwing = true;
                    weapon.Fencing = true;
                    break;

                case "Spear":
                    weapon.Name = "Копьё";
                    weapon.Damage = "1к6 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Universal;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 3;
                    weapon.Throwing = true;
                    break;

                case "LightHammer":
                    weapon.Name = "Лёгкий молот";
                    weapon.Damage = "1к4 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    weapon.Throwing = true;
                    break;

                case "Javelin":
                    weapon.Name = "Метательное копьё";
                    weapon.Damage = "1к6 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    weapon.Throwing = true;
                    break;

                case "Greatclub":
                    weapon.Name = "Палица";
                    weapon.Damage = "1к8 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 10;
                    break;

                case "Handaxe":
                    weapon.Name = "Ручной топор";
                    weapon.Damage = "1к6 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    weapon.Throwing = true;
                    break;

                case "Sickle":
                    weapon.Name = "Серп";
                    weapon.Damage = "1к4 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    break;

                // Простое дальнобойное оружие
                case "CrossbowLight":
                    weapon.Name = "Лёгкий арбалет";
                    weapon.Damage = "1к8 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 5;
                    break;

                case "Dart":
                    weapon.Name = "Дротик";
                    weapon.Damage = "1к4 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 0.25;
                    weapon.Throwing = true;
                    break;

                case "Shortbow":
                    weapon.Name = "Короткий лук";
                    weapon.Damage = "1к6 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 2;
                    break;

                case "Sling":
                    weapon.Name = "Праща";
                    weapon.Damage = "1к4 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 0;
                    break;

                // Воинское рукопашное оружие
                case "Battleaxe":
                    weapon.Name = "Боевой топор";
                    weapon.Damage = "1к8 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.Universal;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 4;
                    break;

                case "Flail":
                    weapon.Name = "Цеп";
                    weapon.Damage = "1к8 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    break;

                case "Glaive":
                    weapon.Name = "Глефа";
                    weapon.Damage = "1к10 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 6;
                    break;

                case "Greataxe":
                    weapon.Name = "Большой топор";
                    weapon.Damage = "1к12 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 7;
                    break;

                case "Greatsword":
                    weapon.Name = "Большой меч";
                    weapon.Damage = "2к6 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 6;
                    break;

                case "Halberd":
                    weapon.Name = "Алебарда";
                    weapon.Damage = "1к10 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 6;
                    break;

                case "Lance":
                    weapon.Name = "Длинное копьё";
                    weapon.Damage = "1к12 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 6;
                    break;

                case "Longsword":
                    weapon.Name = "Длинный меч";
                    weapon.Damage = "1к8 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.Universal;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 3;
                    break;

                case "Maul":
                    weapon.Name = "Молот";
                    weapon.Damage = "2к6 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 10;
                    break;

                case "Morningstar":
                    weapon.Name = "Моргенштерн";
                    weapon.Damage = "1к8 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 4;
                    break;

                case "Pike":
                    weapon.Name = "Пика";
                    weapon.Damage = "1к10 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 18;
                    break;

                case "Rapier":
                    weapon.Name = "Рапира";
                    weapon.Damage = "1к8 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    weapon.Fencing = true;
                    break;

                case "Scimitar":
                    weapon.Name = "Скимитар";
                    weapon.Damage = "1к6 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 3;
                    weapon.Fencing = true;
                    break;

                case "Shortsword":
                    weapon.Name = "Короткий меч";
                    weapon.Damage = "1к6 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    weapon.Fencing = true;
                    break;

                case "Trident":
                    weapon.Name = "Трезубец";
                    weapon.Damage = "1к6 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Universal;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 4;
                    weapon.Throwing = true;
                    break;

                case "WarPick":
                    weapon.Name = "Боевая кирка";
                    weapon.Damage = "1к8 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    break;

                case "Warhammer":
                    weapon.Name = "Боевой молот";
                    weapon.Damage = "1к8 дробящий";
                    weapon.MainDamageType = DamageType.Bludgeoning;
                    weapon.HandWeaponType = HandWeaponType.Universal;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 2;
                    break;

                case "Whip":
                    weapon.Name = "Кнут";
                    weapon.Damage = "1к4 рубящий";
                    weapon.MainDamageType = DamageType.Slashing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Melee;
                    weapon.Weight = 3;
                    break;

                // Воинское дальнобойное оружие
                case "Blowgun":
                    weapon.Name = "Духовая трубка";
                    weapon.Damage = "1 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 1;
                    break;

                case "CrossbowHand":
                    weapon.Name = "Ручной арбалет";
                    weapon.Damage = "1к6 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Light;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 3;
                    break;

                case "CrossbowHeavy":
                    weapon.Name = "Тяжелый арбалет";
                    weapon.Damage = "1к10 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 18;
                    break;

                case "Longbow":
                    weapon.Name = "Длинный лук";
                    weapon.Damage = "1к8 колющий";
                    weapon.MainDamageType = DamageType.Piercing;
                    weapon.HandWeaponType = HandWeaponType.TwoHanded;
                    weapon.WeightWeaponType = WeightWeaponType.Heavy;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 2;
                    break;

                case "Net":
                    weapon.Name = "Сеть";
                    weapon.Damage = "Нет урона";
                    weapon.MainDamageType = DamageType.Piercing; // Можно изменить на SpecialDamage или другой тип
                    weapon.HandWeaponType = HandWeaponType.Default;
                    weapon.WeightWeaponType = WeightWeaponType.Default;
                    weapon.WeaponRangeType = WeaponRangeType.Ranged;
                    weapon.Weight = 3;
                    weapon.Special = true;
                    break;

                default:
                    throw new InvalidOperationException($"Неизвестный тип оружия: {weaponType}");
            }

            
            

            
            var dv = CreateDetailView(weapon, objectSpace);

            OpenDetailView(dv);
        }
    }
}
