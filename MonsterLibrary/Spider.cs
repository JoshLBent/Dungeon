using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary2;

namespace MonsterLibrary
{
    public class Spider : Monster
    {
        public bool IsGiant { get; set; }

        public Spider(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int expValue, bool isGiant)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description, expValue)
        {
            IsGiant = isGiant;
        }//end Spider()

        public Spider()
        {
            MaxLife = 10;
            MaxDamage = 5;
            Name = "Baby Giant Spider";
            Life = MaxLife;
            HitChance = 70;
            Block = 20;
            MinDamage = 1;
            Description = "A big hairy baby giant Brown Recluse";
            ExpValue = 1;
            IsGiant = false;
        }//end Spider()

        public override string ToString()
        {
            return base.ToString() + (IsGiant ? "He is Giant" : "Not quite full grown" );
        }//end

        //Override the block to give the spider 50% better chance if it is giant.
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsGiant == true)
            {
                calculatedBlock += calculatedBlock / 2;
            }//end if
            return calculatedBlock;
        }//end CalcBlock
    }//end clss
}//end namespace
