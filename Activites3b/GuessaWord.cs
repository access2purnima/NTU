using System;

class GuessaWord
{
    //guess a letter function
    static char guessletter()
    {
        char c;

        //Prompt user to guess a letter until user enters valid letter
        do
        {
            Console.Write("\nGuess a letter: ");
            c = Console.ReadKey().KeyChar;
        }
        while (char.IsLetter(c) == false);

        return char.ToLower(c);
    }

    static void Main()
    {
        string[] words = new string[]
        {
            "elephant"
           ,"nottingham"
           ,"london"
        };
        
        char guessingletter;
        int NoofCorrectGuesses = 0
           ,NoofAttempts = 10
           ,randomnumber = new Random().Next(0,words.Length);

        //pick random word
        string word = words[randomnumber];
        int wordlength = word.Length;

        bool[] guess = new bool[wordlength];        
        
        Console.Write("Welcome to the 'Guess a Word' Game.");

        /*
           Loop until all guesses is matched with word or no of attempts exceeded          
        */
        while (wordlength != NoofCorrectGuesses && NoofAttempts > 0)
        {
            //Prompt user to guess a letter
            
            /* Previous logic
            Console.Write("\nGuess a letter: ");
            guessingletter = Console.ReadKey().KeyChar;
            */

            guessingletter = guessletter();

            Console.WriteLine();
            NoofAttempts -= 1;
            
            //Match the guess letter against word
            for (int i = 0; i< wordlength; i++)
            {
                if (word[i] == guessingletter && guess[i] == false)
                {
                    guess[i] = true;
                    NoofCorrectGuesses += 1;
                }

                if (guess[i] == true)
                {
                    Console.Write(word[i]);
                }
                else
                {
                    Console.Write("_");
                }
            }
        } 

        if (NoofAttempts == 0)
        {
            Console.WriteLine("\nYou have reached max no of attempts. Please try again");
        }
        
        if (NoofCorrectGuesses == wordlength)
        {
            Console.WriteLine("\nCongratulations, you guessed it!\nThe word was " + word + ".");
        }

        Console.ReadKey();
    }
}
