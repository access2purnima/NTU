
using System;

class GreetingsProcedure
{
    static void Main()
    {
        //call procedure
        greet("Alan");
        greet("Ada");
        greet("Charles");

        Console.ReadKey();
    }

    //Procedure to display greeting message
    static void greet(string name)
    {
        Console.WriteLine("Hello " + name +".");
        Console.WriteLine("Have a nice day.");
    }
}
