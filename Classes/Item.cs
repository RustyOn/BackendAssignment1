using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public abstract class Item
    {
        protected string name;
        protected int requiredLevel;
        protected Slot slot;

        public Item(string name, int requiredLevel, Slot slot)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
            this.slot = slot;

        }
        //Getters
        public string GetName()
        {
            return name;
        }
        public int GetRequiredLevel()
        {
            return this.requiredLevel;
        }
        public Slot GetSlot()
        {
            return slot;
        }
        public virtual int GetDamage()
        {
            return 0;
        }
        public virtual WeaponType GetWeaponType()
        {
            return 0;
        }
        public virtual ArmorTypes GetArmorType()
        {
            return 0;
        }
        public virtual HeroAttributes GetArmorAttributes()
        {
            return null;
        }
    }
}
