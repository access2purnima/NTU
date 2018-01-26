using System;
using System.IO;
using System.Collections.Generic;

class University_Course_Finder
{
    //Function prompt message and to read string input from console. Prompt again if user enters a empty value
    public static string readString(string prompt)
    {
        string inputText;

        do
        {
            Console.Write(prompt + " : ");
            inputText = Console.ReadLine();
        }
        while (inputText == "");

        return inputText;
    }

    //Function to prompt message and read user choice
    public static int readUserChoice(string prompt, int min, int max)
    {
        int userChoice = 0;
        Console.WriteLine(prompt);
        try
        {
            do
            {                
                userChoice = int.Parse(readString ("Please choose " + min + " to " + max));

                if (userChoice < min || userChoice > max)
                {
                    Console.WriteLine("You have entered the incorrect value.");
                }
            }
            while (userChoice < min || userChoice > max);
        }
        //Call the function again if user enters wrong input
        catch 
        {                        
            userChoice = readUserChoice(prompt, min, max);
        }
        return userChoice;
    }  

    //Function to read files and display the file content. Also returns file exist or not
    public static Boolean courseFileReader(String filePathWithName)
    {
        Boolean fileExists = File.Exists(filePathWithName);

        if (fileExists == true)
        {
            try
            {
                StreamReader inputFileReader = new StreamReader(filePathWithName);

                while (inputFileReader.EndOfStream == false)
                {
                    Console.WriteLine(inputFileReader.ReadLine());
                }
                inputFileReader.Close();
            }
            catch
            {
                Console.WriteLine("Sorry! details are not available. Please contact admin for more details.");
            }
        }
        return fileExists;
    }

    //Function to display the course list and course in Detail
    public static string displayCourseDetails(string courseFilePath,Boolean isAdmin)
    {
        string courseCode = "";
        int userInput;
        Boolean fileExist;

        try
        {      
            do
            {
                Console.WriteLine("\nPlease find the List of courses below");

                fileExist = courseFileReader(courseFilePath + "CourseList.txt");

                if (fileExist == false)
                {
                    throw new Exception("Courses not found.");
                }

                courseCode = readString("\nPlease enter the courseCode to see the in Detail description");

                fileExist = courseFileReader(courseFilePath + courseCode + ".txt");

                if (fileExist == false)
                {
                    throw new Exception("Course description not found.");
                }

                if (isAdmin == false)
                {
                    userInput = readUserChoice("\nWould you like to proceed with registration \n1.Yes \n2.No,go back to course list", 1, 2);
                }
                else
                {
                    userInput = readUserChoice("\nWould you like to search for another course \n1.No\n2.Yes", 1, 2);
                }
               
            }
            while (userInput == 2);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message + "Please contact admin");
            courseCode = "";
        }

        return courseCode;
    }

    //Function to read the student details from console and write to file
    public static void readWriteStudentDetails(string studentFilePath, string courseCode, int maxNoOfPasswordAttempts, string userName)
    {
        const int stringLength = 15
                , rangeMin = 100000
                , rangeMax = 999999;

        const string studentIdPrefix = "N0";

        string prompt              
              , password
              , matchedPassword;

        List<string> studentDetails = new List<string>();

        string[] stundentInputData = new string[]
        {
          "FirstName"
         ,"SurName"
         ,"DOB(dd/mm/yyyy)"
         ,"ContactNo"
         ,"Email"
         ,"HouseNo"
         ,"City"
         ,"County"
         ,"PostCode"         
        };

        //read student details
        Console.WriteLine("\nPlease Enter the following details to complete the registration process");

        try
        {
            for (int i = 0; i < stundentInputData.Length; i++)
            {
                prompt = stundentInputData[i].PadRight(stringLength);
                studentDetails.Add(prompt + " : " + readString(prompt));
            }

            studentDetails.Add("CourseCode".PadRight(stringLength) + " : " + courseCode);

            //ask to enter password and validate it
            do
            {
                password = readString("Password");
                matchedPassword = readString("Please reenter your password");

                if (password != matchedPassword)
                {
                    maxNoOfPasswordAttempts -= 1;
                    Console.WriteLine("Both Passwords didn't match please try again. you have " + maxNoOfPasswordAttempts + " attempts left");                    
                }                
            }
            while (password != matchedPassword && maxNoOfPasswordAttempts > 0);

            if (password != matchedPassword)
            {
                throw new Exception("\nYou have exceeded max no of attempts ");
            }

            //generate unique random number if username is blank
            if (userName == "")
            {                
                do
                {
                    userName = studentIdPrefix + new Random().Next(rangeMin, rangeMax);
                }
                while (File.Exists(studentFilePath + userName + ".txt") == true);                
            }

            studentDetails.Add("UserName".PadRight(stringLength) + " : " + userName);
            studentDetails.Add("Password".PadRight(stringLength) + " : " + password);

            StreamWriter studentFileWriter = new StreamWriter(studentFilePath + userName + ".txt");

            for (int i = 0; i < studentDetails.Count; i++)
            {
                studentFileWriter.WriteLine(studentDetails[i]);
            }

            studentFileWriter.Close();

            Console.WriteLine("\nCongratulations you have successfully registered for the course: " + courseCode +
                        ".\nPlease find the UserId below and you can use the same ID to login in to your account in future.\n" + userName);
        }
        catch(Exception error)
        {
            Console.WriteLine(error.Message + ".Please contact Admin");
        }
    }

    //Procedure to Search for Student Details or Update student details if needed
    public static void searchorUpdateStudentDetails(string courseFilePath, string studentFilePath, Boolean isAdmin, int maxNoOfPasswordAttempts)
    {
        string password               
               , courseCode
               , userName
               , loginPassword;

        const int stringLength = 15;

        int remainingPasswordAttempts = maxNoOfPasswordAttempts;

        List<string> studentDetails = new List<string>();

        try
        {            
            userName = readString("\nUser Name");

            if (File.Exists(studentFilePath + userName + ".txt") == false)
            {
               throw new Exception("UserName doesnot exist.");
            }
            else
            {
                StreamReader studentFileReader = new StreamReader(studentFilePath + userName + ".txt");

                while (studentFileReader.EndOfStream == false)
                {
                    studentDetails.Add(studentFileReader.ReadLine());
                }
                studentFileReader.Close();               

                //for admins no need to ask for password
                if (isAdmin == false)
                {
                    password = studentDetails[11];

                    do
                    {
                        loginPassword = ("Password".PadRight(stringLength) + " : ") + readString("Password");
                        if (password != loginPassword)
                        {
                            remainingPasswordAttempts -= 1;
                            Console.WriteLine("Sorry given password is not valid please try again. you have " + remainingPasswordAttempts + " attempts left");                            
                        }                        
                    }
                    while (password != loginPassword && remainingPasswordAttempts > 0);

                    if (password != loginPassword)
                    {
                        throw new Exception("You have exceeded max no of attempts ");
                    }
                }

                //display student details
                Console.WriteLine("\nPlease find the details below");

                for (int i = 0; i < studentDetails.Count; i++)
                {
                    Console.WriteLine(studentDetails[i]);
                }

                //Edit student details
                if (isAdmin == false)
                {
                    remainingPasswordAttempts = maxNoOfPasswordAttempts;

                    if (readUserChoice("\nWould you like to change your course? \n1.Yes\n2.No", 1, 2) == 1)
                    {
                        courseCode = displayCourseDetails(courseFilePath, isAdmin);

                        if (courseCode != "")
                        {
                            readWriteStudentDetails(studentFilePath, courseCode, maxNoOfPasswordAttempts, userName);
                        }
                    }
                }
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message + "Please contact admin");
        }
    }

    static void Main()
    {
        int userChoice
            , studentChoice
            , adminChoice
            , maxNoOfPasswordAttempts = 3
            , remainingPasswordAttempts = 3;

        string courseCode
               , password = ""               
               , userName = "";

        Boolean isAdmin = true;

        const string courseFilePath = @"C:\NTU\UniversityCourseFinder\CourseDetails\"
                    , studentFilePath = @"C:\NTU\UniversityCourseFinder\StudentRecords\"
                    , adminUserName = "admin"
                    , adminPassword = "admin123";

        Console.WriteLine("Welcome to NTU !");
        userChoice = readUserChoice("\n1.Admin \n2.Student ", 1, 2);

        //Student
        if (userChoice == 2)
        {
            isAdmin = false;
            studentChoice = readUserChoice("\n1.Search for the Course\n2.Login", 1, 2);

            //Course Finder and Student registeration   
            if (studentChoice == 1)
            {
                try
                {
                    courseCode = displayCourseDetails(courseFilePath, isAdmin);

                    if (courseCode != "")
                    {
                        readWriteStudentDetails(studentFilePath, courseCode, maxNoOfPasswordAttempts, userName);                
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message + "Please contact Admin");
                }

            }
            // Student Login
            else
            {
                searchorUpdateStudentDetails(courseFilePath, studentFilePath, isAdmin, maxNoOfPasswordAttempts);
            }
        }
        //Admin
        else
        {
            try
            {
                //validate admin user credentials (Username and password)
                do
                {
                    userName = readString("\nAdmin user name");

                    if (userName != adminUserName)
                    {
                        remainingPasswordAttempts -= 1;
                        Console.WriteLine("Incorrect username please enter the valid username. you have " + remainingPasswordAttempts + " attempts left");                        
                    }
                }
                while (remainingPasswordAttempts > 0 && userName != adminUserName);

                if (remainingPasswordAttempts == 0)
                {
                    throw new Exception("\nYou have exceed max no of attempts.");
                }

                remainingPasswordAttempts = maxNoOfPasswordAttempts;

                do
                { 
                    password = readString("Admin Password");

                    if (adminPassword != password)
                    {
                        remainingPasswordAttempts -= 1;
                        Console.WriteLine("Wrong password please try again. you have " + remainingPasswordAttempts + " attempts left");                        
                    }                    
                }
                while (remainingPasswordAttempts > 0 && password != adminPassword);

                if (remainingPasswordAttempts == 0)
                {
                    throw new Exception("\nYou have exceed max no of attempts.");
                }

                // display Courselist or student details for admin
                adminChoice = readUserChoice("\n1.Search for the course \n2.Search for existing student deatils", 1, 2);
                if (adminChoice == 1)
                {
                    displayCourseDetails(courseFilePath, isAdmin);
                }
                else
                {                   
                    searchorUpdateStudentDetails(courseFilePath, studentFilePath, isAdmin, maxNoOfPasswordAttempts);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message + "Please contact Admin");
            }
        }

        Console.WriteLine("Press any key to Exit");
        Console.ReadKey();
    }
}