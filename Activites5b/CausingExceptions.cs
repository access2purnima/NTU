
using System;
using System.IO;

class CausingExceptions
{
    static void Main()
    {
        try
        {
            int z = 0;
            int x = 3 / z;
        }
        catch
        {
            Console.WriteLine("Cannot devide by zero");
        }

        Console.ReadKey();

        try
        {
            int n = int.Parse("one");
        }
        catch
        {
            Console.WriteLine("Cannot convert string to int");
        }

        Console.ReadKey();

        try
        {
            string[] names = new string[3] { "Ada", "Charles", "Alan" };
            string name = names[5];
        }
        catch
        {
            Console.WriteLine("array outside of index");
        }

        Console.ReadKey();

        try
        {
            StreamReader file = new StreamReader(new FileStream("missing.txt", FileMode.Open));
        }
        catch
        {
            Console.WriteLine("Cannot read the file. file may not exist");           
        }

        Console.ReadKey();
    }
}
