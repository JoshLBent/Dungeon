using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary2
{
    public class Player : Character
    {
        //Fields
        //We only need to create fields for the runs which will have business rules
        //private int _life;

        //Properties
        //Automatic properties are a shortcut syntax which allows you to create a shortended verion of a public property. they have 
        //and OPEN getter and setter (NO BUSINESS RULES). these automatically create default fields for you at runtime.

        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        public RaceClass CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Experience { get; set; }

        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        if (value <= MaxLife && value > 0)
        //        {
        //            _life = value;
        //        }//end if
        //        else
        //        {
        //            _life = MaxLife;
        //        }//end else
        //    }//end set
        //}//end Life

        //CTOR
        //Only make a FQCTOR - we dont want to be able to make a blank player
        public Player(string name, int hitChance, int block, int life, int maxLife, RaceClass characterRace, Weapon equippedWeapon, int experience)
        {
            MaxLife = maxLife;
            Life = life;
            Name = name;
            Block = block;
            HitChance = hitChance;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            Experience = experience;
        }//end player FQCTOR

        //Methods
        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case RaceClass.Knight:
                    description = "You are an obscure knight of poor renown who collapsed roaming the land. Sturdy, owing to high vitality" +
                        "\nand stout armor.";
                    break;
                case RaceClass.Mercenary:
                    description = "A Mercenary and veteran of the battlefield. High dexterity allows masterful wielding of dual scimitars.";
                    break;
                case RaceClass.Warrior:
                    description = "You are a Warrior descendant of northern warriors famed for their brawn." +
                        "Utilizes high strength to wield\na heavy battleaxe.";
                    break;
                case RaceClass.Herald:
                    description = "A former herald who journeyed to finish a quest undertaken." +
                        "Wields a sturdy spear and employs a gentle\nrestorative miracle.";
                    break;
                case RaceClass.Thief:
                    description = "You are a common thief and pitiful deserter. Wields a dagger intended for backstabs alongside a\nmilitary-issue bow.";
                    break;
                case RaceClass.Assassin:
                    description = "You are an Assassin who stalks their prey from the shadows. Favors sorceries in addition to thrusting\nswords.";
                    break;
                case RaceClass.Sorcerer:
                    description = "You are a Sorcerer, a loner who left formal academia to pursue further research." +
                        " Commands soul sorceries\nusing high intelligence.";
                    break;
                case RaceClass.Pyromancer:
                    description = "You are a pyromancer from a remote region who manipulates flame." +
                        " Also an adept close combat warrior who\nwields a hand axe.";
                    break;
                case RaceClass.Cleric:
                    description = "You are a traveling cleric who collapsed from exhaustion. Channels high faith to cast many and varied\nmiracles.";
                    break;
                case RaceClass.Deprived:
                    description = "You are deprived. Naked and of unknown origin. Either an unimaginable fool in life," +
                        " or was stripped of\npossessions upon burial.";
                    break;
            }//end switch

            return string.Format("\n***** {0} *****\nLife: {1} of {2}\nHit Chance: {3}%\nWeapon:\n{4}\nDescription: {5}" + 
                "\nSoul Experience: {6}",
                Name.ToUpper(),
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                description,
                Experience);
        }//end ToString override

        //Override CalcDamage() to use the players weapons properties of minDamage and maxdamage. Also override CalcHitchance to add
        //the weapons property of BonusHitChance

        public override int CalcDamage()
        {
            ////return base.CalcDamage();
            //Random rand = new Random();

            ////determine the damage
            //int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            //return damage;

            //alternative

            return (new Random()).Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }//end CalcDamage

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance() override
    }
}
