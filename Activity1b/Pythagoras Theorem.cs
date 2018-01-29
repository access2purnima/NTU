using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            hypotenuseLength = Math.Sqrt((Traingle_side1 * Traingle_side1) + (Traingle_side2 * Traingle_side2));            

            Console.Write("Length of the hypotenuse: " + hypotenuseLength);
            Console.ReadKey();
        }
    }
}
