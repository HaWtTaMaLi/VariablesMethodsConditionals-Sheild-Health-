using System;

namespace VariablesMethodsConditionals_Sheild_Health_
{
    internal class Program
    {
        //Health
        static int health;
        static int currHealth;
        //Shield
        static int shield;
        static int currShield;
        //Lives
        static int lives;
        static int currLives;
        static int livesToDeplete;

        static void Main()
        {
            //set the game colour
            Console.ForegroundColor = ConsoleColor.Gray;
            //set stats
            health = 100;
            shield = 100;
            lives = 3;
            livesToDeplete = 1;
            currShield = shield;
            currHealth = health;
            currLives = lives;

            HUD();
            TakeDamage(75); 
            HUD();
            TakeDamage(110);
            HUD();
            TakeDamage(75);
            HUD();
            TakeDamage(110);
            HUD();
            TakeDamage(75);
            HUD();
            TakeDamage(110);
            HUD();
            TakeDamage(75);
            HUD();
            TakeDamage(110);
            HUD();
            TakeDamage(75);
            HUD();
            TakeDamage(110);
            HUD();
            TakeDamage(75);
            HUD();
            TakeDamage(110);
            HUD();
            TakeDamage(75);
            HUD();
            TakeDamage(110);
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
            // apply damage to shield
            currShield = currShield - dmg;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Shield took damage. -" + dmg + ""); //i have to leave the "" in there cuz the .exe is angry
            Console.ForegroundColor = ConsoleColor.Gray;

            //if the damage is greater then the currShield
            //check if shield is 0
            ShieldCheck();

            //i had to move this back up to the top because the values wouldn't change
            //// apply damage to shield
            //currShield = currShield - dmg;
            //Console.WriteLine("Shield took damage. -" + dmg + ""); //i have to leave the "" in there cuz the .exe is angry

            //if health equales 0 
            //check if health is 0
            HealthCheck();
        }

        static void ResetHealthandShield()
        {
            //reset health to default
            currHealth = health;
            //reset shield to default
            currShield = shield;
        }

        static void ShieldCheck()
        {
            ////Debugging
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Debugging: Checking to see if ShieldCheck is being triggered");
            //Console.ForegroundColor = ConsoleColor.Gray;
            ////

            //if the damage is greater then the currShield
            //check if shield is 0
            if (currShield <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Health took damage. " + currShield); //this isnt being triggered??
                Console.ForegroundColor = ConsoleColor.Gray;

                //if shield is 0
                //store the remaining damage
                int remainingDMG = -currShield; // -currShield because the remaining damage -
                //- was in the negative

                //Remove the remaining damage off of health
                currHealth = currHealth - remainingDMG;

                //set the shield to 0
                currShield = 0;
                //stop the cap LOL

                ////Debugging
                ////how much damage is left?
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("DebugLine: CurrentShield " + currShield);
                //Console.ForegroundColor = ConsoleColor.Gray;
                ////
            }
        }

        static void HealthCheck()
        {
            ////Debugging
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Debugging: Checking to see if HealhtCheck is being triggered");
            //Console.ForegroundColor = ConsoleColor.Gray;
            ////

            //if health is 0 
            //check if health is 0
            if (currHealth <= 0)
            {
                //if health is 0
                //set the health
                currHealth = 0;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You lost a life. " + currLives);
                Console.ForegroundColor = ConsoleColor.Gray;

                //remove a life
                currLives = currLives - livesToDeplete;

                //restore health and shield
                ResetHealthandShield();

                //if you have no lives left
                //check if you have no lives left
                if (currLives < 0)
                {
                    //set the lives to 0
                    currLives = 0;
                    currShield = 0;
                    currHealth = 0;

                    //you died!
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Died!");
                    Console.WriteLine("Game Over!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    HUD();
                    Console.Read(); //this is just to stop you from seeing the other attemps that will continue after you hit a button 
                    //unless you hit the button lol
                }
            }
        }
    }
}
