
using System; 
    class EnterPassword
{
    static void Main()
    {
        string Guess, Guess1, Guess3;
        int Attempt = 0;
        
        //Create a password
        do
        {
            Console.Write("Please Create your password:");
            Guess = Console.ReadLine();

            Console.Write("Reenter the password:");
            Guess1 = Console.ReadLine();

            if (Guess != Guess1)
            {
                Console.WriteLine("Both passwords didnot match Please try again");
            }
        }
        while (Guess != Guess1);

        Console.WriteLine("Password Created");

        //Login with a new password
        do
        {
            Console.Write("Enter newly created password to login:");
            Guess3 = Console.ReadLine();
            Attempt = Attempt + 1;

            if (Guess3 != Guess)
            {
                Console.WriteLine("Wrong password please reenter the password again.");
            }
            else
            {
                Console.WriteLine("Log-in Successful");
            }
        }
        while (Attempt < 3);

        if (Guess3 != Guess)
        { 
            Console.WriteLine("Log-in Failed");
        }

        Console.ReadKey();
    }
}
