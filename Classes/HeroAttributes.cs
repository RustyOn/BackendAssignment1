using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    public class HeroAttributes
    {
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }

        //Define a method for handling adding HeroAttributes to each other - return a new HeroAttributes object
        public static HeroAttributes operator +(HeroAttributes lhs, HeroAttributes rhs)
        {
            return new HeroAttributes
            {
                Strength = lhs.Strength + rhs.Strength,
                Intelligence = lhs.Intelligence + rhs.Intelligence,
                Dexterity = lhs.Dexterity + rhs.Dexterity
            };
        }

        //Increases each attribute by the specified amount
        public void IncreaseAttribute(int strength, int dexterity, int intelligence)
        {
            Strength += strength;
            Intelligence += intelligence;
            Dexterity += dexterity;
        }

    }
}
