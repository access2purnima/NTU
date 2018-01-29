using System;

   class Quiz_Questions
    {
        static void Main()
        {
        int Answer, score=0;
        
        // Question:1
        Console.WriteLine("Welcome to Quiz Program!");
        Console.ReadKey();

        Console.Write("What is the Capital city of Britain?");
        Console.WriteLine("\n1.Manchester \n2.London \n3.Birmingham \n4.Liverpool");
        Answer = int.Parse(Console.ReadLine());
       
        if (Answer == 2)
        {
            Console.WriteLine("correct");
            score = score + 1;
        }
            
        else 
        {
            Console.WriteLine("incorrect");
        }   

        //Question:2
        Console.Write("What is the capital city of India?");
        Console.WriteLine("\n1.Newdelhi \n2.Hyderabad \n3.Mumbai \n4.Vijayawada");
        Answer = int.Parse(Console.ReadLine());

        if (Answer ==1)
        {
            Console.WriteLine("correct");
             score = score + 1;
        }
        else
        {
            Console.WriteLine("incorrect");
        }        

        //Question:3
        Console.Write("What is the capital city of USA?");
        Console.WriteLine("\n1.Hamilton \n2.Newyork \n3.Columbus \n4.Washington, D.C.");
        Answer = int.Parse(Console.ReadLine());

        if (Answer == 4)
        {
            Console.WriteLine("correct");
            score = score + 1;
        }
        else
        {
            Console.WriteLine("incorrect");
        }

        Console.WriteLine("You score is : " + score);        
         
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey();

        }
    }
