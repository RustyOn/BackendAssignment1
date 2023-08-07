using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public class Wizard : Hero
    {
        //Set class base stats and valid equipment
        public Wizard(string name) : base(name)
        {
            this.className = "Wizard";
            this.Name = name;
            this.LevelAttribute = new HeroAttributes { Strength = 1, Dexterity = 1, Intelligence = 8 };
            this.ValidWeapons = new List<WeaponType>();
            this.ValidWeapons.Add(WeaponType.Staffs);
            this.ValidWeapons.Add(WeaponType.Wands);

            this.ValidArmors = new List<ArmorTypes>();
            this.ValidArmors.Add(ArmorTypes.Cloth);
        }

        //When leveling up increase the attributes specific to the class
        public override void LevelUp()
        {
            base.LevelUp();
            this.LevelAttribute.IncreaseAttribute(1, 1, 5);
        }

        //Calculate the damage based on the class
        public override double Damage()
        {
            int weaponDamage = 1;
            if (this.Equipment[Slot.Weapon] != null)
            {
                weaponDamage = this.Equipment[Slot.Weapon].GetDamage();
            }
            double heroDamage = weaponDamage * (1 + this.TotalAttributes().Intelligence / 100);
            return heroDamage;
        }
    }
}
