using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary2;//added
using MonsterLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LOST SOULS";
            int score = 0;
            int level = 1;
            int floor = 1;

            bool creationLoop = false;
            do
            {
                #region ClassMenu

                bool classLoop = false;
                Console.Write("Enter your name mortal: ");
                string playerName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Welcome to certain death, " + playerName + ".");
                Console.ResetColor();

                //TODO create a player
                Weapon longSword = new Weapon(1, 16, "Longsword", 10, false);
                Weapon dualScimi = new Weapon(7, 13, "Dual Scimitars", 12, true);
                Weapon battleAxe = new Weapon(10, 20, "Battle Axe", 5, true);
                Weapon banditsDagger = new Weapon(1, 7, "Bandits Dagger", 30, false);
                Weapon spear = new Weapon(5, 10, "A long Spear", 15, true);
                Weapon estoc = new Weapon(10, 16, "Estoc", 10, true);
                Weapon sorcerersStaff = new Weapon(7, 12, "Sorcerers Staff of the Vinheim Dragon School", 35, false);
                Weapon mancyFlame = new Weapon(10, 17, "Pyromancy Flame", 10, false);
                Weapon chimeAndMace = new Weapon(7, 15, "Mace and Sacred Chime", 10, true);
                Weapon woodenClub = new Weapon(1, 11, "Wooden Club", 7, true);

                Player player = new Player(playerName, 70, 45, 20, 20, RaceClass.Knight, longSword, 0);

                do
                {
                    Console.Write("\nSELECT A CLASS:\n" +
                        "K) KNIGHT\n" +
                        "M) MERCENARY\n" +
                        "W) WARRIOR\n" +
                        "H) HERALD\n" +
                        "T) THEIF\n" +
                        "A) ASSASSIN\n" +
                        "S) SORCERER\n" +
                        "P) PYROMANCER\n" +
                        "C) CLERIC\n" +
                        "D) DEPRIVED\n>");
                    string userClass = Console.ReadLine().ToUpper();
                    if (userClass.Length > 0)
                    {
                        userClass = userClass.Substring(0, 1);//pulls out the first letter of input
                    }//end if
                    switch (userClass)
                    {
                        case "K":
                            Console.WriteLine("You are an obscure knight of poor renown who collapsed roaming the land. Sturdy, owing to high vitality" +
                        " and stout\narmor.");
                            break;
                        case "M":
                            player.CharacterRace = RaceClass.Mercenary;
                            player.EquippedWeapon = dualScimi;
                            Console.WriteLine("A Mercenary and veteran of the battlefield. High dexterity allows masterful wielding of dual scimitars.");
                            break;
                        case "W":
                            player.CharacterRace = RaceClass.Warrior;
                            player.EquippedWeapon = battleAxe;
                            Console.WriteLine("You are a Warrior descendant of northern warriors famed for their brawn." +
                        " Utilizes high strength to wield a heavy\nbattleaxe.");
                            break;
                        case "H":
                            player.CharacterRace = RaceClass.Herald;
                            player.EquippedWeapon = spear;
                            Console.WriteLine("A former herald who journeyed to finish a quest undertaken." +
                        "Wields a sturdy spear and employs a gentle\nrestorative miracle.");
                            break;
                        case "T":
                            player.CharacterRace = RaceClass.Thief;
                            player.EquippedWeapon = banditsDagger;
                            Console.WriteLine("You are a common thief and pitiful deserter. Wields a dagger intended for backstabs alongside a military-issue bow.");
                            break;
                        case "A":
                            player.CharacterRace = RaceClass.Assassin;
                            player.EquippedWeapon = estoc;
                            Console.WriteLine("You are an Assassin who stalks their prey from the shadows. Favors sorceries in addition to thrusting swords.");
                            break;
                        case "S":
                            player.CharacterRace = RaceClass.Sorcerer;
                            player.EquippedWeapon = sorcerersStaff;
                            Console.WriteLine("You are a Sorcerer, a loner who left formal academia to pursue further research." +
                        " Commands soul sorceries using\nhigh intelligence.");
                            break;
                        case "P":
                            player.CharacterRace = RaceClass.Pyromancer;
                            player.EquippedWeapon = mancyFlame;
                            Console.WriteLine("You are a pyromancer from a remote region who manipulates flame." +
                        " Also an adept close combat warrior who wields a\nhand axe.");
                            break;
                        case "C":
                            player.CharacterRace = RaceClass.Cleric;
                            player.EquippedWeapon = chimeAndMace;
                            Console.WriteLine("You are a traveling cleric who collapsed from exhaustion. Channels high faith to cast many and varied miracles.");
                            break;
                        case "D":
                            player.CharacterRace = RaceClass.Deprived;
                            player.EquippedWeapon = woodenClub;
                            Console.WriteLine("You are deprived. Naked and of unknown origin. Either an unimaginable fool in life," +
                        " or was stripped of possessions upon burial.");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("You must still be a little cloudy, try again Lost Soul.");
                            break;
                    }//end switch

                    Console.Write("Would you like to continue? Y/N: ");
                    string continue1 = Console.ReadLine().ToUpper();

                    switch (continue1)
                    {
                        case "Y":
                        case "YES":
                            classLoop = true;
                            break;
                        case "N":
                        case "NO":
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("There is only 2 paths. Try again.");
                            break;
                    }//end switch

                } while (!classLoop);
                Console.Clear();

                #endregion
                bool exit = false;
                do
                {
                    Console.WriteLine("Floor {0}:", floor);
                    Console.WriteLine(GetRoom());

                    Spider s1 = new Spider(); //uses the default CTOR to set the values
                    Spider s2 = new Spider("Giant Spider", 20, 20, 70, 20, 6, 15, "Full Grown Giant Spider", 2, true);

                    //Since all of our child monsters are of the type monster, we can store them in an array[] or monster or List<Monster>
                    Monster[] monsters =
                    {
                        s1, s1, s1, s2
                    };

                    //Randomly select monster from an array
                    Random rand = new Random();
                    int randomNbr = rand.Next(monsters.Length);
                    Monster monster = monsters[randomNbr];
                    Console.WriteLine("In this room: " + monster.Name);

                    bool reload = false;
                    do
                    {
                        #region Menu
                        Console.Write("\n*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*\n" + 
                            "A) ATTACK\n" + 
                            "R) RUN AWAY\n"+
                            "C) CHARACTER INFO\n" +
                            "M) MONSTER INFO\n" +
                            "X) EXIT\n"+ 
                            "Choose your fate: ");

                        string userFate = Console.ReadLine().ToUpper();
                        if (userFate.Length > 0)
                        {
                            userFate = userFate.Substring(0, 1);//pulls out the first letter of input
                        }//end if

                        Console.Clear();
                        switch (userFate)
                        {
                            case "A":
                                //TODO handle if monster kill player
                                Combat.DoBattle(player, monster);
                                if (monster.Life <= 0)
                                {
                                    //ITS DEAD
                                    Console.WriteLine("\nYou deafeated {0}... Beginners luck.", monster.Name);
                                    reload = true;
                                    score++;
                                    floor++;
                                    player.Experience += monster.ExpValue;
                                    if (player.Experience % 20 == 0)
                                    {
                                        level++;
                                        player.MaxLife += 5;
                                        player.Life = player.MaxLife;
                                        Console.WriteLine("You have gained a new soul...you now have {0} soul{1}",
                                            level,
                                            level == 1 ? "." : "s");
                                    }//end if
                                }//end if monster is dead
                                break;
                            case "R":
                                Console.WriteLine("You try to run away...");
                                Combat.DoAttack(monster, player);
                                reload = true;
                                break;
                            case "C":
                                Console.WriteLine(player);
                                Console.WriteLine("Monsters defeated: " + score);
                                break;
                            case "M":
                                Console.WriteLine();
                                Console.WriteLine(monster);
                                break;
                            case "E":
                            case "X":
                                Console.WriteLine("You have chosen the quitters fate, you will forever be dubbed a n00b.");
                                Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s"));
                                exit = true;
                                creationLoop = true;
                                break;
                            default:
                                Console.WriteLine("You cannot escape your fate, try again!");
                                break;
                        }//end switch

                        #endregion

                        if (player.Life <=0)
                        {
                            Console.WriteLine("You Died");
                            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s"));
                            reload = true;
                            creationLoop = true;
                        }//end if
                    } while (!reload && !exit);//end do while

                } while (!exit && !creationLoop);//could also do - exit == false;
            } while (!creationLoop);

        }//end main()
        private static string GetRoom()
        {
            string[] rooms =
            {
                 "A flurry of bats suddenly flaps through the doorway, their screeching barely audible as they careen past your heads.\nThey flap past you into the rooms and halls beyond. The room from which they came seems barren at first glance.",
                 "A dozen statues stand or kneel in this room, and each one lacks a head and stands in a posture of action or defense.\nAll are garbed for battle. It's difficult to tell for sure without their heads, but two appear to be dwarves, one might be an elf, six appear human, and the rest look like they might be orcs.",
                 "A stone throne stands on a foot-high circular dais in the center of this cold chamber. The throne and dais bear the\nsimple adornments of patterns of crossed lines -- a pattern also employed around each door to the room.",
                 "You inhale a briny smell like the sea as you crack open the door to this chamber. Within you spy the source of the\nscent: a dark and still pool of brackish water within a low circular wall. Above it stands a strange statue of a\nlobster-headed and clawed woman. The statue is nearly 15 feet tall and holds the lobster claws crossed over its naked\nbreasts.",
                 "Dozens of dead, winged beings lie scattered about the floor, each about the size of a cat. Their broken bodies are\nbatlike and buglike at the same time. Each had two sets of bat wings, a long nose like a mosquito, and six legs, but\nmany were split in half or had limbs or wings lopped off. Their forms are little more than dried husks now, and there's no sign of what killed them.",
                 "You open the door to what must be a combat training room. Rough fighting circles are scratched into the surface of\nthe floor. Wooden fighting dummies stand waiting for someone to attack them. A few punching bags hang from the ceiling.\nThere's something peculiar about it all though. Every dummy is stocky and each has a bedraggled piece of leather\nhanging from its head that could be a long mask or a beard.",
                 "The strong, sour-sweet scent of vinegar assaults your nose as you enter this room. Sundered casks and broken bottle\nglass line the walls of this room. Clearly this was someone's wine cellar for a time. The shards of glass are somewhat\ndusty, and the spilled wine is nothing more than a sticky residue in some places. Only one small barrel remains\nunbroken amid the rubbish."
            };//end rooms[]
            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }//end GetRoom
    }//end class
}//end namespace
