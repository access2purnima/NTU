using System;

namespace Pythagoras_Theorem
{
    class Program
    {
        static void Main(string[] args)
        {
            double Traingle_side1, Traingle_side2, hypotenuseLength;

            Console.Write("Please enter the length of first short side: ");
            Traingle_side1 = int.Parse(Console.ReadLine());

            Console.Write("Please enter the length of second short side: ");
            Traingle_side2 = int.Parse(Console.ReadLine());

            //Calculate hypotenuse Length
            //hypotenuseLength = Math.Sqrt((Traingle_side1 * Traingle_side1) + (Traingle_side2 * Traingle_side2));  //Previous logic
            hypotenuseLength = hypotenuseof(Traingle_side1, Traingle_side2);

            Console.Write("Length of the hypotenuse: " + hypotenuseLength);
            Console.ReadKey();
        }

        //function to calculate hypotenuse length
        static double hypotenuseof(double a,double b)
        {
            double h = Math.Sqrt(sqr(a) + sqr(b));
            return h;
        }

        //function to return square
        static double sqr(double x)
        {
            return (x * x);
        }
    }
}
