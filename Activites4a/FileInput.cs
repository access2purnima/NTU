
using System;
using System.IO;

class FileInput
{
    static void Main()
    {
        StreamReader infile = new StreamReader("TestInputfile.txt");

        string line1 = infile.ReadLine();

        Console.WriteLine(line1);

        infile.Close();

        Console.ReadKey();
    }
}
