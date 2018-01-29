
using System; 
    class function
{
    static void Main()
    {
        string Firstname,Familyname;
		int age;
        Console.Write("Enter your First name: ");
        Firstname = Console.ReadLine();
        Console.Write("Enter your Family name: ");
        Familyname = Console.ReadLine();
        Console.WriteLine("Hello " + Firstname + " " + Familyname );
        Console.ReadLine();
        Console.Write("Enter your age: ");
        age = int.Parse(Console.ReadLine());
        Console.WriteLine("You will be " + age + 1 + " years old this time next year");
        Console.ReadKey();
    }
}
