
using System; 
    class Cinema
{
    static void Main()
    {
        string Pop_Liked;
        int age, Choosenfilmno;

        Console.WriteLine("Welcome to NTU Cinema!");
        Console.ReadKey();

        Console.Write("Enter your name: ");
        Console.ReadLine();

        Console.Write("Enter your age: ");
        age = int.Parse(Console.ReadLine());

        //Display films ntil user chooses right filmno
        do
        {

            Console.WriteLine("Currently showing: \n1.The Imitation Game (12) \n2.The Social Network (12) \n3.Steve Jobs(15)");
            Console.Write("Enter the number of the film you would like to see:");
            Choosenfilmno = int.Parse(Console.ReadLine());           
        }
        while (Choosenfilmno >3);

        //Check user age against age rating of the film
        if (((Choosenfilmno == 1 || Choosenfilmno == 2) && age >= 12) || ((Choosenfilmno == 3) && age >= 15))
        {
            //Ask user for popcorn
            Console.Write("Would you like some popcorn:");
            Pop_Liked = Console.ReadLine();

            if (Pop_Liked == "yes" || Pop_Liked == "y")
            {
                Console.WriteLine("Enjoy your popcorn");
            }

            Console.WriteLine("Enjoy the film");
        }
        else
        {
            Console.WriteLine("Sorry you are not allowed to watch this film");
        }

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
