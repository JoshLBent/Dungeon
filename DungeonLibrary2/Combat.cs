using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary2
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            //Get a random # from 1 - 100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(20);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //the attacker hit! calculate the damage
                int damageDealt = attacker.CalcDamage();
                //assign the damage
                defender.Life -= damageDealt;

                //write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!",
                    attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }//end if
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }//end DoAttack

        public static void DoBattle(Player player, Monster monster)
        {
            //Player attacks first
            DoAttack(player, monster);

            //monster attacks next if they are alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }//end if
        }//end method
    }//end Combat
}//end namespace
