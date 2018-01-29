using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Bill_Calulator
{
    class Program
    {
        static string readString(string prompt)
        {
            string result;

            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            }
            while (result == "");

            return result;
        }

        //FUNCTION TO read positive decimal value
        static decimal readPositiveDecimal(string prompt)
        {
            decimal itemcost;

            do
            {
                string decimalString = readString(prompt);

                itemcost = decimal.Parse(decimalString);
            }
            while (itemcost < 0);            

            return itemcost;
        }

        static void Main()
        {
            decimal Starter_Cost
                   ,MainCourse_Cost
                   ,Dessert_Cost
                   ,Drinks_Cost
                   ,Total_Cost;

            int TotalNoofPeople;

            Console.Write("Please enter the Cost of the following items.\n");
            Console.ReadLine();

            /* previous logic
            Console.Write("Starter :£");
            Starter_Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Main Course :£");
            MainCourse_Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Dessert :£");
            Dessert_Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Drinks :£");
            Drinks_Cost = decimal.Parse(Console.ReadLine());
            */

            Starter_Cost = readPositiveDecimal("Starter :£");
            MainCourse_Cost = readPositiveDecimal("Main Course :£");
            Dessert_Cost = readPositiveDecimal("Dessert :£");
            Drinks_Cost = readPositiveDecimal("Drinks :£");
            
            //Total cost of the all items
            Total_Cost =  Starter_Cost + MainCourse_Cost + Dessert_Cost + Drinks_Cost;            

            Console.Write("Your total bill is £" + Math.Round(Total_Cost,2));
            Console.ReadLine();

            //Total bill with 10% tip
            Console.Write("Your total bill with 10% tip is £" + Math.Round((Total_Cost - (Total_Cost * (decimal)0.10)),2));
            Console.ReadLine();

            //Total bill with 20% tip
            Console.Write("Your total bill with 20% tip is £" + Math.Round((Total_Cost - (Total_Cost * (decimal)0.20)),2));
            Console.ReadLine();

            Console.Write("How many people are sharing the cost of the bill: ");
            TotalNoofPeople = int.Parse(Console.ReadLine());

            //Shared bill for each person
            Console.Write("Each person should pay £" + Math.Round(Total_Cost /TotalNoofPeople,2));
            Console.ReadKey();

        }
    }
}
