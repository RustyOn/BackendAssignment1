using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public class Armor : Item
    {
        private ArmorTypes armorType;
        private HeroAttributes ArmorAttributes;

        public Armor(string name, int requiredLevel, Slot slot, ArmorTypes armorType, HeroAttributes armorAttributes) : base(name, requiredLevel, slot)
        {
 
            this.armorType = armorType;
            this.ArmorAttributes = armorAttributes;
        }

        override public HeroAttributes GetArmorAttributes()
        {

            return ArmorAttributes;
        }

        public override ArmorTypes GetArmorType()
        {
            return this.armorType;
        }
    }
}
