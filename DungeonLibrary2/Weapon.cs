using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary2
{
    public class Weapon
    {
        //fields - DO NOT NEED TO ADD THE PRIVATE, the default is private.
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private bool _isTwoHanded;
        private int _bonusHitCHance;

        //properties
        //properties with business rules go last
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end name
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded
        public int BonusHitChance
        {
            get { return _bonusHitCHance; }
            set { _bonusHitCHance = value; }
        }//end BonusHitChance
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //Cant be more than the max damage && cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    //tried to set the value outside the range
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage

        //CTOR
        public Weapon() { }//default

        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            //If you have any properties that have business rules that are based off of any other properties, set the OTHER properties first.
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//end Weapon()

        //Methods
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\nBonus Hit: {3}%\t{4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                IsTwoHanded == true ? "Two Handed" : "One Handed");
        }//end ToString() override
    }
}
