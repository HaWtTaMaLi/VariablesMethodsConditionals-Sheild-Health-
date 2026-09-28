using System;
using System.Xml.Serialization;

namespace VariablesMethodsConditionals_Sheild_Health_
{
    internal class Program
    {
        static int currHealth;
        static int health;
        static int currShield;
        static int shield;
        static int currLives;
        static int lives;
        static int livesToDeplete;

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            health = 100;
            shield = 100;
            lives = 3;
            livesToDeplete = 1;
            currShield = shield;
            currHealth = health;
            currLives = lives;

            //HUD();
            //TakeDamage(25); // results: shield = 75; health = 100
            HUD();
            TakeDamage(75); // results: shield = 25; health = 100
            HUD();
            TakeDamage(110);
            HUD();
        }

        static void HUD()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--Player HUD--");
            Console.WriteLine("Health: " + currHealth);
            Console.WriteLine("Shield: " + currShield);
            Console.WriteLine(" Lives: " + currLives);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void TakeDamage(int dmg)
        {
            //add if statment up here

            // apply damage to shield
            currShield = currShield - dmg;
            Console.WriteLine("Shield took damage. -" + dmg + " dmg");

            //if (currShield < 0)
            //{
            //    // save spillover
            //    int spillOver = -currShield;

            //    // cap shield at 0 (don't allow negatives)
            //    currShield = 0;

            //    // handle the spill over...

            //}


            // if there is spill over
            // (if dmg is greater then shield)
            if (currShield < 0)
            //if (dmg > currShield) // !!! 
            {
                //store the remaining dmg
                //int remainingDMG;

                //remainingdmg now equals currShield 
                //remainingDMG = currShield;
                //it will be in the negative (ex; -10)

                Console.WriteLine("curr health: " + currHealth + " curr Shield: " + currShield);

                //take remaining and remove from health
                //currHealth = currHealth + currShield; // because currShield is negative and has the minus sign in it

                // calculate remaining damage
                // (from the overflow of damage to the shield which overflowed into the negatives)
                int remainingDMG = -currShield;
                    // explanation: the shield damage when over and into negatives, we save the overage as a positive
                    // explanation: cover the negative overflow left in shield into a positive amount to save in remaining damage
                //int remainingDMG = Math.Abs(currShield); // explanation: the shield damage when over and into negatives, we save the overage as a positive
                
                // apply remaining damage to health
                currHealth = currHealth - remainingDMG;

                //how much damage is left?
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(currShield);
                Console.ForegroundColor = ConsoleColor.Gray;

                //set to 0
                currShield = 0;

            }

            if (currHealth < 0)
            {
                currHealth = 0; //set the health

                currLives = currLives - livesToDeplete; //remove a life

                Console.WriteLine("You lost a life. " + currLives);

                ResetHealthShield(); //restore health and shield

                //if you have no lives left
                if (currLives <= 0)
                {
                    Console.WriteLine("You Died!");
                    Console.WriteLine("Game Over!");

                }
            }

        }

        static void ResetHealthShield()
        {
            currHealth = 100;
            currShield = 100;
        }
    }
}
