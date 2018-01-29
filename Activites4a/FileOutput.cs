
using System;
using System.IO;

class FileOutput
{
    static void Main()
    {
        StreamWriter outfile = new StreamWriter("output.txt");

        outfile.WriteLine("Hello World");
        outfile.WriteLine("file overwritten");

        outfile.Close();
    }
}
