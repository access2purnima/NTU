using System;
using System.IO;

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
        int result =0;

        do
        {
            string intString = readString(prompt);
            
            //repeat it unitl user enters correct value
            try
            {
                result = int.Parse(intString);
            }
            catch
            {
                readInt(prompt, low, high);
            }
        }
        while ((result < low) || (result > high));
        return result;
    }

    static void Main()
    {
        string Pop_Liked;
        int age, Choosenfilmno,nooffilms;
        string[] filmsList= new string[3];
        int[] filmRatings = new int[3];

        string InputFileName = "FilmsList.txt";

        StreamReader filmsInfo = new StreamReader(InputFileName);        

        //Read the films from Input file 
        for(int i=0; i< filmsList.Length; i++)
        {                          
            filmsList[i] = filmsInfo.ReadLine();
            filmRatings[i] = int.Parse(filmsInfo.ReadLine());           
        }

        filmsInfo.Close();

        nooffilms = filmsList.Length;

        Console.WriteLine("Welcome to NTU Cinema!");
        Console.ReadKey();

        Console.Write("Enter your name: ");
        Console.ReadLine();

        age = readInt("Enter your age:", 0, 120);
        
        //Display all films again until user chooses right filmno
        do
        {
            Console.WriteLine("Currently showing:");

            //Display all films
            for (int i = 0; i < nooffilms; i++)
            {
                Console.WriteLine(i + "." + filmsList[i] + " (" + filmRatings[i] + ")");
            }
            
            Choosenfilmno = readInt("Enter the number of the film you would like to see:", 0, nooffilms-1);
        }
        while (Choosenfilmno >= nooffilms);

        //Check whether the user allowed watch the film based on their age v/s film age rating
        if (age >= filmRatings[Choosenfilmno])
        {
            //Ask user for popcorn
            Console.Write("Would you like some popcorn:");
            Pop_Liked = Console.ReadLine().ToUpper();

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
