using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public class Archer : Hero
    {
        //Set class base stats and valid equipment
        public Archer(string name) : base(name)
        {
            this.className = "Archer";
            this.Name = name;
            this.LevelAttribute = new HeroAttributes { Strength = 1, Dexterity = 7, Intelligence = 1 };
            this.ValidWeapons = new List<WeaponType>();
            this.ValidWeapons.Add(WeaponType.Bows);

            this.ValidArmors = new List<ArmorTypes>();
            this.ValidArmors.Add(ArmorTypes.Leather);
            this.ValidArmors.Add(ArmorTypes.Mail);
        }
        //When leveling up increase the attributes specific to the class
        public override void LevelUp()
        {
            base.LevelUp();
            this.LevelAttribute.IncreaseAttribute(1, 5, 1);
        }
        //Calculate the damage based on the class
        public override double Damage()
        {
            int weaponDamage = 1;
            if (this.Equipment[Slot.Weapon] != null)
            {
                weaponDamage = this.Equipment[Slot.Weapon].GetDamage();
            }
            double heroDamage = weaponDamage * (1 + this.TotalAttributes().Dexterity / 100);
            return heroDamage;
        }
    }
}
