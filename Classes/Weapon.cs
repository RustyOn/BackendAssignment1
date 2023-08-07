using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public class Weapon : Item
    {
        private WeaponType weaponType;
        private int weaponDamage;
        public Weapon(string name, int requiredLevel, Slot slot, WeaponType weaponType, int weaponDamage) : base(name, requiredLevel, slot)
        {
            slot = Slot.Weapon;
            this.weaponType = weaponType;
            this.weaponDamage = weaponDamage;
        }
        override public int GetDamage()
        {
            return weaponDamage;
        }
        override public WeaponType GetWeaponType()
        {
            return weaponType;
        }
    }
}
