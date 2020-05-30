using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary2
{
    public abstract class Character
    {
        private int _life;
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }//end if
                else
                {
                    _life = MaxLife;
                }//end else
            }//end set
        }//end Life

        //Since we dont inherit constructors and we already did a lot of work defining the Players FQCTOR, we will not create on here.
        //We still get thefree default parameterless one, but we will not be able to use it since this class is abstract.

        //Methods
        //No need to override the ToString(). we will never create the character object.
        //It will always be a Player or Monster.

        public virtual int CalcBlock()
        {
            //To be able to override this method in the child class we made it virtual.

            //This basic version just returns Block, but this gives us the option to do something different in child classes.
            return Block;
        }//end CalcBlock()

        //MINI LAB make the CalcHitChance() return hit chance

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance

        public virtual int CalcDamage()
        {
            //Start this with just returning 0. So that we can use the method froma an instance of a character, we will override the method
            //in Monster and Player
            return 0;
        }// end CalcDamage()
    }
}
