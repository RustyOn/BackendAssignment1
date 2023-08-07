using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public class Barbarian : Hero
    {
        //Set class base stats and valid equipment
        public Barbarian(string name) : base(name)
        {
            this.className = "Barbarian";
            this.Name = name;
            this.LevelAttribute = new HeroAttributes { Strength = 5, Dexterity = 2, Intelligence = 1 };
            this.ValidWeapons = new List<WeaponType>();
            this.ValidWeapons.Add(WeaponType.Hatchets);
            this.ValidWeapons.Add(WeaponType.Maces);
            this.ValidWeapons.Add(WeaponType.Swords);

            this.ValidArmors = new List<ArmorTypes>();
            this.ValidArmors.Add(ArmorTypes.Mail);
            this.ValidArmors.Add(ArmorTypes.Plate);
        }
        //When leveling up increase the attributes specific to the class
        public override void LevelUp()
        {
            base.LevelUp();
            this.LevelAttribute.IncreaseAttribute(3, 2, 1);
        }
        //Calculate the damage based on the class
        public override double Damage()
        {
            int weaponDamage = 1;
            if (this.Equipment[Slot.Weapon] != null)
            {
                weaponDamage = this.Equipment[Slot.Weapon].GetDamage();
            }
            double heroDamage = weaponDamage * (1 + this.TotalAttributes().Strength / 100);
            return heroDamage;
        }
    }
}
