using System;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Guess a number (1-100): ");            
            Random random = new Random();
            int pcNum = random.Next(1, 101);
            int userNum = 0;
            
            while (userNum != pcNum)
            {
                if(!int.TryParse(Console.ReadLine(), out userNum))
                {
                    Console.WriteLine("Invalid Input!");
                    Console.Write("Guess a number (1-100): ");
                    continue;
                }
                if (userNum > pcNum)
                {
                    Console.WriteLine("Too High");
                    Console.Write("Guess a number (1-100): ");
                }
                else if (userNum < pcNum)
                {
                    Console.WriteLine("Too Low");
                    Console.Write("Guess a number (1-100): ");
                }                
            }
            Console.WriteLine("You guessed it!");
        }
    }
}
