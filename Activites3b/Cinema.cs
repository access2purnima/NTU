
using System; 
    class Cinema
{
    static string readString(string prompt)
    {
        string result;

        do
        {
            Console.Write(prompt); result = Console.ReadLine();
        }
        while (result == "");

        return result;
    }

    static int readInt(string prompt, int low, int high)
    {
        int result;

        do
        {
            string intString = readString(prompt);

            result = int.Parse(intString);
        }
        while ((result < low) || (result > high));
        return result;
    }

    static void Main()
    {
        string Pop_Liked;
        int age, Choosenfilmno,nooffilms;

        //Enter film names
        string[] Films = new string[]
        {
            "The Imitation Game",
            "The Social Network",
            "Steve Jobs",
            "IT",
            "Dunkirk",
            "Test"
        };

        //Enter Age ratings for the film
        int[] Ageratings = new int[]
        {
            12,12,15,18,18,19
        };

        nooffilms = Films.Length;

        Console.WriteLine("Welcome to NTU Cinema!");
        Console.ReadKey();

        Console.Write("Enter your name: ");
        Console.ReadLine();

        //Console.Write("Enter your age: ");   //Previous logic
        //age = int.Parse(Console.ReadLine()); //Previous logic       
        age = readInt("Enter your age:", 0, 120);

        //Display films ntil user chooses right filmno
        do
        {
            //Console.WriteLine("Currently showing: \n1.The Imitation Game (12) \n2.The Social Network (12) \n3.Steve Jobs(15)"); //previous logic
            Console.WriteLine("Currently showing:");

            //Get List of films into string
            for (int i = 0; i < nooffilms; i++)
            {
                Console.WriteLine(i + "." + Films[i] + " (" + Ageratings[i] + ")");
            }

            //Console.Write("Enter the number of the film you would like to see:");  //Previous logic
            //Choosenfilmno = int.Parse(Console.ReadLine());                         //Previous logic
            Choosenfilmno = readInt("Enter the number of the film you would like to see:", 0, nooffilms-1);
        }
        while (Choosenfilmno >= nooffilms);

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
