using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Bill_Calulator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal Starter_Cost
                   ,MainCourse_Cost
                   ,Dessert_Cost
                   ,Drinks_Cost
                   ,Total_Cost;

            int TotalNoofPeople;

            Console.Write("Please enter the Cost of the following items.\n");
            Console.ReadLine();

            Console.Write("Starter :£");
            Starter_Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Main Course :£");
            MainCourse_Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Dessert :£");
            Dessert_Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Drinks :£");
            Drinks_Cost = decimal.Parse(Console.ReadLine());

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
