
using System; 
    class Cinema
{
    static void Main()
    {
        string Pop_Liked;
        int age, Choosenfilmno;

        //Enter film names
        string[] Films = new string[]
        {
            "The Imitation Game",
            "The Social Network",
            "Steve Jobs",
            "IT",
            "Dunkirk"
        };

        //Enter Age ratings for the film
        int[] Ageratings = new int[]
        {
            12,12,15,18,18
        };

        Console.WriteLine("Welcome to NTU Cinema!");
        Console.ReadKey();

        Console.Write("Enter your name: ");
        Console.ReadLine();

        Console.Write("Enter your age: ");
        age = int.Parse(Console.ReadLine());        

        //Display films ntil user chooses right filmno
        do
        {
            //Console.WriteLine("Currently showing: \n1.The Imitation Game (12) \n2.The Social Network (12) \n3.Steve Jobs(15)"); \\previous logic
            Console.WriteLine("Currently showing:");

            //Get List of films into string
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i + "." + Films[i] + " (" + Ageratings[i] + ")");
            }

            Console.Write("Enter the number of the film you would like to see:");
            Choosenfilmno = int.Parse(Console.ReadLine());           
        }
        while (Choosenfilmno >= 5);

        //Check user age against age rating of the film
        //if (((Choosenfilmno == 1 || Choosenfilmno == 2) && age >= 12) || ((Choosenfilmno == 3) && age >= 15)) //Previous logic
        if (age >= Ageratings[Choosenfilmno])
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
