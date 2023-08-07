using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public abstract class Hero
    {
        protected string Name { get; set; }
        protected int level;
        protected HeroAttributes LevelAttribute;
        protected string className;

        protected Dictionary<Slot, Item> Equipment;

        protected List<WeaponType> ValidWeapons;
        protected List<ArmorTypes> ValidArmors;

        public Hero(string name)
        {
            //Setting base values shared by all heroes
            this.Name = name;
            this.level = 1;
            //Populating the Equipment with null references - All heroes are equipped with null value Items
            this.Equipment = new Dictionary<Slot, Item>
            {
                { Slot.Weapon, null },
                { Slot.Head, null },
                { Slot.Body, null },
                { Slot.Legs, null }
            };

        }

        //Increases the Hero level - each Class overrides this method
        public virtual void LevelUp()
        {
            this.level++;
            //Console.WriteLine("Leveled up! Current level: " + level);
        }

        //Returns a string that contains the class name, hero name, hero level, the total of each attribute and how much damage the hero does
        public string Display()
        {
            string display = $"The {this.className} Hero {this.Name} is level {this.level} \n" +
                $"Strength: {this.TotalAttributes().Strength} \n" +
                $"Dexterity: {this.TotalAttributes().Dexterity} \n" +
                $"Intelligence: {this.TotalAttributes().Intelligence} \n" +
                $"The {this.className} does {this.Damage()} damage!";

            return display;
        }

        //Runs the appropriate equip method if the hero level meets the requirements - otherwise throws an exception
        public void Equip(Item item)
        {
            if (this.level >= item.GetRequiredLevel())
            {
                if (item.GetSlot() == Slot.Weapon)
                {
                    EquipWeapon(item);
                }
                else
                {
                    EquipArmor(item);
                }
            }
            else
            {
                throw new InvalidLevelException("The hero does not meet the required level!");
            }
        }

        //If the armor type matches a valid armor type for the hero class => equips the armor in the correct slot - Otherwise throws an exception that the armor type is invalid
        public void EquipArmor(Item item)
        {
             foreach(var a in this.ValidArmors)
            {
                if(a == item.GetArmorType())
                {
                    this.Equipment[item.GetSlot()] = item;
                    return;
                }
            }
            throw new InvalidArmorException("The hero cannot equip that type of armor due to their class!");
        }

        //If the weapon type matches a valid weapon type for the hero class => equips the weapon in the weapon slot - Otherwise throws an exception that the weapon type is invalid
        public void EquipWeapon(Item item)
        {
            foreach(var w in this.ValidWeapons)
            {
                if(w == item.GetWeaponType())
                {
                    this.Equipment[Slot.Weapon] = item;
                    return;
                }
            }
            throw new InvalidWeaponException("The hero cannot equip a weapon of that type!");
        }

        //Returns the total attributes which are ArmorAttributes + LevelAttributes
        public HeroAttributes TotalAttributes()
        {
            HeroAttributes totalAttributes = new HeroAttributes();
            HeroAttributes totalArmorAttributes = new HeroAttributes();

            //Loops through all equipment that is not null or a weapon
            foreach(var a in Equipment)
            {
                if(a.Key != Slot.Weapon && a.Value != null)
                {
                    totalArmorAttributes += a.Value.GetArmorAttributes();
                }
            }
            totalAttributes = this.LevelAttribute + totalArmorAttributes;

            return totalAttributes;
        }

        public abstract double Damage();
        public string GetName()
        {
            return this.Name;
        }
        public int GetLevel()
        {
            return this.level;
        }
        public HeroAttributes GetLevelAttributes()
        {
            return this.LevelAttribute;
        }
        public Item GetEquipment(Slot slot)
        {
            return this.Equipment[slot];
        }
    }
}
