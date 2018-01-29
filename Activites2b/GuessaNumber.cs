
using System;

class GuessaNumber
{
    public static void Main()
    {
        int GuessingNumber = 0,Attempts;

        //Generate random number between 1 and 100
        int PseudoNumber = new Random().Next(1, 100);

        Console.WriteLine("Welcome to the 'Guess a Number' Game. \nYou have to guess an integer between 1 and 100");

        //Ask user to enter the guessing number for 10 times
        for (Attempts = 10; Attempts > 0; Attempts = Attempts -1)
        {
            Console.WriteLine("You have " + Attempts + " attempts left");
            Console.Write("What is your guess: ");

            GuessingNumber = int.Parse(Console.ReadLine());

            if (GuessingNumber < PseudoNumber)
            {
                Console.WriteLine("Too low!");
            }
            else if (GuessingNumber > PseudoNumber)
            {
                Console.WriteLine("Too high!");
            }
            else if (GuessingNumber == PseudoNumber)
            {
                Console.WriteLine("Congratulations! The number was " + PseudoNumber + ".");
                break;
            }                     
        }

        //when user has no attempts left 
        if (Attempts == 0)
        {
            Console.WriteLine("You have exceeded no of attempts");
        }

        Console.ReadKey();
    }
}
