using System;
using System.Collections.Generic;

namespace GuessNumber
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Please select difficuly.You can choose between : [E]asy , [M]edium , [H]ard");
            string playerDifficulty;
            List<string> possibleDifficulty = new List<string> { "easy", "medium", "hard", "e", "m", "h" };
            int tries = 0;
            int currLevel = 1;
            while (true)
            {
                playerDifficulty = Console.ReadLine().ToLower();
                bool flag = false;

                if(!possibleDifficulty.Contains(playerDifficulty))
                {
                    Console.WriteLine("Please input either the first letter or the whole word of the selected difficulty!");
                    continue;
                }

                for(int i = 0; i < possibleDifficulty.Count; i++)
                {
                    if(possibleDifficulty[i] == playerDifficulty)
                    {                        
                        if (playerDifficulty == "e" || playerDifficulty == "easy")
                        {
                            tries = 10;
                            Console.WriteLine("You have chosen easy difficulty.");
                            Console.WriteLine("You have 10 tries to guess.");
                        }
                        else if (playerDifficulty == "m" || playerDifficulty == "medium")
                        {
                            tries = 6;
                            Console.WriteLine("You have chosen medium difficulty.");
                            Console.WriteLine("You have 6 tries to guess.");
                        }
                        else if (playerDifficulty == "h" || playerDifficulty == "hard")
                        {
                            tries = 3;
                            Console.WriteLine("You have chosen hard difficulty.");
                            Console.WriteLine("You have 3 tries to guess.");
                        }
                        flag = true;
                        break;
                    }
                }

                if(flag)
                {
                    break;
                }
            }

            int upperNumber = 101;

            for (int i = 0; i < 1; i++)
            {       
                if(currLevel == 6)
                {
                    Console.WriteLine("You are very good at guessing.You WIN!");
                    return;
                }
                Random random = new Random();
                int pcNum = random.Next(1, upperNumber);

                for ( int j = 0; j < tries; j++)
                {
                    Console.Write($"Guess a number (1-{upperNumber - 1}): ");
                    if (!int.TryParse(Console.ReadLine(), out int userNum))
                    {
                        j--;
                        Console.WriteLine("Invalid Input!");                        
                        continue;
                    }
                    if (userNum > pcNum)
                    {
                        if(userNum > upperNumber - 1)
                        {
                            j--;
                            Console.WriteLine("Please choose a valid number!");
                            continue;
                        }
                        Console.WriteLine("Too High");                        
                    }
                    else if (userNum < pcNum)
                    {
                        if (userNum < 1)
                        {
                            j--;
                            Console.WriteLine("Please choose a valid number!");
                            continue;
                        }
                        Console.WriteLine("Too Low");                        
                    }
                    else
                    {                        
                        upperNumber += 100;                       
                        currLevel++;
                        i--;
                        Console.WriteLine("You guessed it!");
                        if (upperNumber > 600)
                        {                            
                            upperNumber = 1001;
                            Console.WriteLine("You are playing the last level 6!");
                            break;
                        }
                        Console.WriteLine($"You have gone up one level to level {currLevel}!");
                        break;
                    }
                }                
            }
            Console.WriteLine("You loose!");
            Console.WriteLine("Do you want to play again?");
            string playAgain = Console.ReadLine().ToLower();

            if(playAgain == "yes")
            {
                Main();
            }
            else if (playAgain == "no")
            {
                Console.WriteLine($"You ended your strike at level {currLevel}");
            }
        }
    }
}
