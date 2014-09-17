using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulator2
{
    class Program
    {
        //store points for player and dragon
        static int playerHitPoints = 100;
        static int dragonHitPoints = 200;
        //random number constructor
        static Random rng = new Random();


        static void Main(string[] args)
        {
            //print to console a greeting, and instructions to player
            Console.WriteLine("Welcome to DragonCombatSimulator!");
            //print to console to ask for player's name
            Console.WriteLine("What is your name?");
            //declare a string variable to store the player's name
            string input = Console.ReadLine();
            //print to console the game's instructios
            Console.WriteLine("Hello " + input + ", Let's play!" +
                "\n " +
                "\nHere are some instructions:" +
                "\nAttack with a sword will damage dragon by about" +
                "\n20 to 35 points, but only hit 70 percent of the time." +
                "\nAttack with a magic fireball will hit all the time, but" +
                "\nonly damage dragon by about 10 to 20 points." +
                "\nHeals can heal the player by about 10 to 20 points." +
                "\nDragon attacks after the player, and hits about 80" +
                "\npercent of the time for damages of about 5 to 15 points to player." +
                "\nGOOD LUCK " + input.ToUpper() + "!");

            //a section divider to make the output look more presentable on console.
            Console.WriteLine(" ");
            
            //print to console instructing player on the required input to commence the game
            Console.WriteLine("Enter 1 if you want to attack with sword. " +
               "\nEnter 2 if you want to attack with magic." +
               "\nEnter 3 if you want to heal your wound for 10 to 20 points.");
            
            //enter an extra line to separate sections  
            Console.WriteLine();
            
            //a while loop with the conditions for how long the game can be played
            while (playerHitPoints > 0 || dragonHitPoints > 0)
            {
            
                //instruct player to enter a number for each type of attack available 
                Console.WriteLine("ENTER 1, 2 or 3 TO PLAY");
                Console.WriteLine(" ");
                
                //declare a variable to store the player's choice of weapon from 1,2 or 3
                int playerChoice = int.Parse(Console.ReadLine());
                
                //call the PlayerAttack function and send the players choice of weapon as a parameter
                PlayerAttack(playerChoice);
                
                //call the DragonAttack funtion to receive the dragons score
                DragonAtack();
                
                //An if/else if condition to end the game
                //When player runs out of points he or she loses to dragon and the game ends.
                if (playerHitPoints <= 0)
                
                
                {
                    //print to console letting the player know he or she lost and ask if they want to play again
                    Console.WriteLine("OUUUUUCH! YOU LOSE!" +
                        "\nYOU HAVE NO POINTS LEFT, SO YOU LOSE!");
                    Console.WriteLine("GAME OVER! WANT TO PLAY AGAIN?");
                
                    //break out of the loop
                    break;

                }
                
                    //when the dragon runs out of points it loses
                else if (dragonHitPoints <= 0)
                {
                    //print to console congratulating the layer,and ask if they want to play again.
                    
                    Console.WriteLine("CONGRATULATIONS! YOU HAVE WON!" +
                        "\nDRAGON IS OUT OF POINTS, SO IT LOST!");
                    Console.WriteLine("WANT TO PLAY AGAIN?");
                    
                    //break out of the loop
                    break;
                }

            }

            //keep console open
            Console.ReadKey();
        }
       
        
        //create a function PlayerAttack that takes an integer parameter to calculate the
        //player's score count
        static void PlayerAttack(int Choice)
        {
           
            //an if/else if condition to test which option was chosen by the player
            //if choice 1 execute the following code
            if (Choice == 1)
            {
               
                //print to the console what choice the player made
                Console.WriteLine("You have chosen sword as you method of attack!");
                Console.WriteLine(" ");
               
                //get a random number from 1 to 100 and store it in an integer variable
                int hitOrMiss = rng.Next(1, 101);
               
                //check a condition if the stored random number is less than or equal to 70
                //and execute the following code if true
                if (hitOrMiss <= 70)
                {
                  
                    //get a random number between 20 and 35 and store in an int variable
                    int swordHit = rng.Next(20, 36);
                   
                    //print to the console to inform player has scored a hit and for how many points
                    Console.WriteLine("Boom! You hit the Dragon for " + swordHit + " points");
                   
                    //subtract the points player scored from the dragon's totla points
                    dragonHitPoints -= swordHit;
                   
                    //print to console remaining dragon points
                    Console.WriteLine("Dragon has " + dragonHitPoints + " points left");
                  
                    //print to console remaining player points
                    Console.WriteLine("You still have " + playerHitPoints + " left");
                    Console.WriteLine();

                }
              
                    //if player failed to score print to console and inform the player has missed.
                else
                {
                    //if player's random intial random pics are greater than 70, print to console he or she missed.
                    Console.WriteLine("Sorry, You Missed!" + "\nIt is the Dragon's turn to strike, good luck!");
                    Console.WriteLine();

                }
            }
          
                //if player chose 2 print to console the chose method of attack, and execute the code inside
            else if (Choice == 2)
            {
                //print to console choice
                Console.WriteLine("You have chosen magic as you method of attack!");
                Console.WriteLine(" ");
               
                //pick a random number between 10 and 16 and store in an int variable
                int magicHit = rng.Next(10, 16);
               
                //print to console informing player has scored a hit, and for how many points
                Console.WriteLine("Nice! You hit the Dragon for " + magicHit + " points");
               
                //subtract the points scored from the dragon's total
                dragonHitPoints -= magicHit;
                
                //print to console remaining points for dragon
                Console.WriteLine("Dragon has " + dragonHitPoints + " points left");
                
                //print to console remaining points for player
                Console.WriteLine("You still have " + playerHitPoints + " left");

            }
            //choice 3 enter by player
            else if (Choice == 3)
            {
                //print to console player made choice 3 to console
                Console.WriteLine("You have chosen to heal your wound instead of attacking!");
                Console.WriteLine(" ");
                //get a random number between 10 and 20 and store it in an int variable 
                int healCost = rng.Next(10, 21);
                //test the condition to see if the total points available for player equal 100
                if (playerHitPoints == 100)
                {
                    //print to console informing player no more points allowed, he or she has max amount possible
                    Console.WriteLine("Sorry, but you already have the maximum points allowed");
                }
                //test the condition to see if total player points are less than 100
                else if (playerHitPoints < 100)
                {
                   
                    //subtract healing points awarded and add it player's total points and store in a new int variable
                    int pointDiff = playerHitPoints + healCost;
                   
                    //test the condition to see if the the new player total is less than 100
                    if (pointDiff < 100)
                    {
                        //if the above condition is true add healpoints to the player's points
                        playerHitPoints += healCost;
                        //print to console informing player he or she now has the new total added
                        Console.WriteLine("You're being rewarded " + healCost + " points" +
                            "\nso, you now have " + playerHitPoints + " points.");

                    }
                    //test the condition to see if healpoints added to the player total  are greater than 100
                    else if (pointDiff > 100)
                    {
                        //print to console informing player he or she had the original points
                        Console.WriteLine("You had " + playerHitPoints + " points and");
                        //because player is only allowed 100 points discard the difference and award return 100 for 
                        //new total player points
                        playerHitPoints = 100;
                        //print to console how many points player has been awarded
                        Console.WriteLine("Ok, you now have " + playerHitPoints + " points.");

                    }
                }
            }
            //section divider
            Console.WriteLine(" ");
        }

        //create function DragonAttack
        static void DragonAtack()
        {
            //pick random number between 1 and 100 and store it in hitOrMiss
            int hitOrMiss = rng.Next(1, 101);
            //check a condition to see if the  hit is less than or equal to 80
            if (hitOrMiss <= 80)
            {
                //if the above condition is true get a random number between 5 and 15 and assign it to an int variable 
                int dragonScore = rng.Next(5, 16);
                //print to console that dragon has scored a hit and show by how many points
                Console.WriteLine("But dragon hit you for " + dragonScore);
                //take the points scored by dragon and subtract them from the player's available points
                playerHitPoints -= dragonScore;
                //print to console how many points player has left at this point
                Console.WriteLine("So, you now have " + playerHitPoints + " points");
                //print to console how many player points are available
                Console.WriteLine("And Dragon has " + dragonHitPoints + " points");
                Console.WriteLine(" ");
            }
            //if dragon misses execute the following codes
            else
            {
                //print to console that dragon missed and that player still has his points
                Console.WriteLine("Dragon Missed, so you still have " + playerHitPoints + " points.");
               
                //print to console how many points dragon has to this point
                Console.WriteLine("And Dragon has " + dragonHitPoints + " point");
                Console.WriteLine(" ");
            }
        }

    }
}