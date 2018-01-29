
using System;

class ArtificialIntelligence
{
    public static void Main()
    {
        string UserResponse;
        int range_min = 1
           ,range_max = 100
           ,GuessingNumber;

        Console.WriteLine("Welcome to the 'Guess a Number' Game. \nYou have to pick a number between 1 and 100, and I will try to guess it.");

        Console.WriteLine("Press any key when you are ready to begin.");
        Console.ReadKey();
        Console.Write("\n");        

        do
        {
            GuessingNumber = new Random().Next(range_min, range_max);

            Console.Write("I guess " + GuessingNumber + ".  Am I right? ");

            UserResponse = Console.ReadLine().ToLower();

            if (UserResponse == "high")
            {
                range_max = GuessingNumber - 1;
            }
            else if (UserResponse == "low")
            {
                range_min = GuessingNumber + 1;
            }
            else if (UserResponse == "correct")
            {
                Console.WriteLine("Haha, I am good at this.");
                break;
            }

            if (range_min > range_max)
            {
                Console.WriteLine("You rotter, you lied to me.");
                break;
            }            
        }
        while (UserResponse != "correct");

        Console.ReadKey();
    }
}
