using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary2
{
    public class Monster : Character
    {
        //field & prop
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int ExpValue { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //Cant be more than max damage and cannot be less than one
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage

        //CTOR
        public Monster() { }
        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int expValue)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            Block = block;
            MinDamage = minDamage;
            HitChance = hitChance;
            Description = description;
            ExpValue = expValue;
        }//end Monster()

        //methods
        public override string ToString()
        {
            return string.Format("\n***** {0} *****\nLife: {1} of {2}\nDamage: {3} to {4}\nBlock: {5}\nDescription:\n{6}\n",
                Name.ToUpper(),
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }//end ToString() override

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage() override
    }//end class
}//end namespace
