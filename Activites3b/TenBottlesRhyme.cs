
using System;

class TenBottlesRhyme
{
    //define singular or plural string
    static string bottlesString(int i)
    {
        string result;

        if (i > 1)
        {
            result = "bottles";
        }
        else
        {
            result = "bottle";
        }
        return result;
    }

    static void Main()
    {
        string BottleColor,Rhyme;

        Console.Write("Which colour do you perfer for the bottle: ");
        BottleColor = Console.ReadLine();

        for(int i=10; i >0; i--)
        {
            /* Previous logic
            if (i>2)
            {
                Rhyme = i + " " + BottleColor + " bottles sitting on the wall,\n"
                               + i + " " + BottleColor + " bottles sitting on the wall,\n"
                               + "and if one " + BottleColor + " bottle should accidentally fall,\n"
                               + "there'll be " + (i - 1) + " " + BottleColor + " bottles sitting on the wall.\n";
            }
            else if (i == 2)
            {
                Rhyme = i + " " + BottleColor + " bottles sitting on the wall,\n"
                               + i + " " + BottleColor + " bottles sitting on the wall,\n"
                               + "and if one " + BottleColor + " bottle should accidentally fall,\n"
                               + "there'll be " + (i - 1) + " " + BottleColor + " bottle sitting on the wall.\n";
            }
            else
            {
                Rhyme = i + " " + BottleColor + " bottle sitting on the wall,\n"
                               + i + " " + BottleColor + " bottle sitting on the wall,\n"
                               + "and if one " + BottleColor + " bottle should accidentally fall,\n"
                               + "there'll be " + (i - 1) + " " + BottleColor + " bottle sitting on the wall.\n";

            } */

            Rhyme = i + " " + BottleColor + " " + bottlesString(i) + " sitting on the wall,\n"
                           + i + " " + BottleColor + " " + bottlesString(i) + " sitting on the wall,\n"
                           + "and if one " + BottleColor + " " + bottlesString(i) + " should accidentally fall,\n"
                           + "there'll be " + (i - 1) + " " + BottleColor + " " + bottlesString(i-1) + " sitting on the wall.\n";

            Console.WriteLine(Rhyme);
        }

        Console.ReadKey();
    }
}
