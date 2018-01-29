using System;

class Quiz_Questions
{
    static void Main()
    {
        int Answer, score=0;

        //Insert all questions
        string[] quiz_questions = new string[3]
        {
            "What is the Capital city of Britain?", //\n1.Manchester \n2.London \n3.Birmingham \n4.Liverpool",
            "What is the capital city of India?",   //\n1.Newdelhi \n2.Hyderabad \n3.Mumbai \n4.Vijayawada",
            "What is the capital city of USA?"      //\n1.Hamilton \n2.Newyork \n3.Columbus \n4.Washington, D.C."
        };

        //Insert multiple choices for the above questions
        string[,] QuizAnswers_Choices = new string[3, 4]
        {
            {"Manchester" ,"London"    ,"Birmingham"  ,"Liverpool"},
            {"Newdelhi"   ,"Hyderabad" ,"Mumbai"      ,"Vijayawada"},
            {"Hamilton"   ,"Newyork"   ,"Columbus"    ,"Washington, D.C."}
        };

        //Insert answers
        int[] Answers = new int[3]
        {
            2,1,4
        };
        
        Console.WriteLine("Welcome to Quiz Program!");
        Console.ReadKey();

        //Ask user all questions one by one
        for (int i=0; i<3; i++)
        {
            Console.WriteLine(quiz_questions[i]);

            //Get all choices from 2d array
            for (int j=0; j<4; j++)
            {
                Console.WriteLine( (j+1) + "." + QuizAnswers_Choices[i,j]);
            }            

            Answer = int.Parse(Console.ReadLine());

            //if answer is corect
            if(Answer == Answers[i])
            {
                Console.WriteLine("correct");
                score = score + 1;
            }
            else
            {
                Console.WriteLine("incorrect");
            }
        }

        /* Previous logic
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
        */

        Console.WriteLine("You score is : " + score);        
         
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey();
    }
}
