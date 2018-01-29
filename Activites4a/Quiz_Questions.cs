using System;
using System.IO;

class Quiz_Questions
{
    static void Main()
    {
        int Answer, score=0;

        //Insert all questions
        string[] quiz_questions = new string[3];

        //Insert multiple choices for the above questions
        string[,] QuizAnswers_Choices = new string[3, 4];
    
        //Insert answers
        int[] Answers = new int[3];

        //Read quiz questions and answers from input file
        StreamReader Quizinputfile = new StreamReader("Quizquestions.txt");
        
        //Loop through file and read each line
        for (int i=0; i<quiz_questions.Length; i++)
        {
            quiz_questions[i] = Quizinputfile.ReadLine();

            for (int j=0; j < QuizAnswers_Choices.GetLength(1); j++)
            {
                QuizAnswers_Choices[i,j] = Quizinputfile.ReadLine();
            }

            Answers[i] = int.Parse(Quizinputfile.ReadLine());
        }             
        
        Console.WriteLine("Welcome to Quiz Program!");
        Console.ReadKey();

        //Ask user all questions one by one
        for (int i=0; i< quiz_questions.Length; i++)
        {
            Console.WriteLine(quiz_questions[i]);

            //Get all choices from 2d array
            for (int j=0; j< QuizAnswers_Choices.GetLength(1); j++)
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

        Console.WriteLine("You score is : " + score);        
         
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey();
    }
}
