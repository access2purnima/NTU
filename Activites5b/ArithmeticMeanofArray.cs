
using System;

class ArithmeticMean
{
    //function to calculate arithmatic mean of array
    static double mean(double[] array)
    {
        double sum = 0;

        if (array.Length == 0)
        {
            throw new Exception("cannot compute the arithmetic mean of an empty array");
        }

        for(int i=0;i<array.Length;++i)
        {
            sum += array[i];
        }
        return (sum / array.Length);
    }

    static void Main()
    {
        double[] numbers = new double[3] { 1, 2, 3 };
        double[] emptyarray = new double[0];

        //Calculate arithematic mean of above arrays 
        try
        {
            Console.WriteLine(mean(numbers));
            Console.WriteLine(mean(emptyarray));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}
