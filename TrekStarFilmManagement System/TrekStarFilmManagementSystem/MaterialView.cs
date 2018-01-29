using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TrekStarFilmManagementSystem
{
    class materialsView
    {
        string adminPasword = ConfigurationSettings.AppSettings.Get("adminpassword");

        public string readString(string displayval)
        {
            string inputVal;

            do
            {
                Console.Write(displayval + ":");
                inputVal = Console.ReadLine();
            }
            while (inputVal == "");

            return inputVal;
        }

        public int readUserChoice(string displayval, int min, int max)
        {
            int userChoice = 0;
            Console.WriteLine(displayval);
            try
            {
                do
                {
                    userChoice = int.Parse(readString("Please choose " + min + " to " + max));

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
                userChoice = readUserChoice(displayval, min, max);
            }
            return userChoice;
        } 

        public void displayMaterialList(List<MaterialModel> lstMaterials)
        {
            if (lstMaterials.Count > 0)
            {
                Console.WriteLine("\nPlease Find the below materials info");
            }
            else
            {
                Console.WriteLine("\nNo materials found");
            }

            foreach (MaterialModel materialInfo in lstMaterials)
            {
                Console.WriteLine("IdentificationNumber".PadRight(25) + ": " + materialInfo.IdentificationNumber);
                Console.WriteLine("Title".PadRight(25) + ": " + materialInfo.title);
                Console.WriteLine("ProjectTitle".PadRight(25) + ": " + materialInfo.projectTitle);
                Console.WriteLine("MaterialType".PadRight(25) + ": " + materialInfo.materialType);
                Console.WriteLine("Format".PadRight(25) + ": " + materialInfo.format);
                Console.WriteLine("AudioFormat".PadRight(25) + ": " + materialInfo.audioFormat);
                Console.WriteLine("RunTime".PadRight(25) + ": " + materialInfo.runTime);
                Console.WriteLine("ReleaseDate".PadRight(25) + ": " + materialInfo.releaseDate);
                Console.WriteLine("Launguage".PadRight(25) + ": " + materialInfo.launguage);
                Console.WriteLine("RetailPrice".PadRight(25) + ": " + materialInfo.retailPrice);
                Console.WriteLine("SubTitles".PadRight(25) + ": " + materialInfo.subTitles);
                Console.WriteLine("FrameAspect".PadRight(25) + ": " + materialInfo.frameAspect);
                Console.WriteLine("Packaging".PadRight(25) + ": " + materialInfo.packaging);
                Console.WriteLine("AddedDate".PadRight(25) + ": " + materialInfo.addedDate);
                Console.WriteLine("AddedBy".PadRight(25) + ": " + materialInfo.addedBy);
                Console.WriteLine("\n");
            } 
        }

        public Boolean initialse()
        {
            string isAdmin,inputPassword;
            
            Boolean returnVal = false;

            Console.WriteLine("Welcome to TrekStart film management system");

            do
            {
                isAdmin = readString("\nAre you Admin (Y/N)?");
            }
            while (isAdmin.ToUpper() != "Y" && isAdmin.ToUpper() != "N");

            if (isAdmin.ToUpper() == "Y")
            {
                //verify login details
                do
                {
                    inputPassword = readString("\nPlease Enter Your Password");

                    if (inputPassword != adminPasword)
                    {
                        Console.WriteLine("\nYou have Entered Incorrect Password");
                    }
                }
                while (inputPassword != adminPasword);

                returnVal = true;
            }
            return returnVal;
        }

        public string userOptions(Boolean IsAdmin)
        {
            int userInputChoice;

            string userChoiceText = "";

            if (IsAdmin == true)
            {
                Console.WriteLine("\nPlease choose from one of the below action");

                userInputChoice = readUserChoice("1. Searh Material \n2. Create Material \n3. Update Material \n4. Delete Material",1,4);

                if (userInputChoice == 1)
                {
                    userChoiceText = "Search";
                }
                else if (userInputChoice == 2)
                {
                    userChoiceText = "Add";
                }
                else if (userInputChoice == 3)
                {
                    userChoiceText = "Update";
                }
                else if (userInputChoice == 4)
                {
                    userChoiceText = "Delete";
                }
            }
            else
            {
                userChoiceText = "Search";
            }

            return userChoiceText;
        }

        public MaterialModel readMaterialInfo(MaterialModel materialInfo)
        {
            string[,] materialPackageTypes = new string[,]
            {
              {"Single Sided DVD","Plastic box"}
             ,{"Double Sided DVD","Plastic box"}
             ,{"Combo box sets Contains two DVDs","Cardboard box"}
             ,{"Combo box sets Contains three DVDs","Cardboard box"}
             ,{"VHS","Plastic box"}
             ,{"Blu-rays","Plastic box"}
            };

            int choiceInput;

            try
            {
                materialInfo.title = readString("Title");
                materialInfo.projectTitle = readString("Project Title");

                Console.WriteLine("Please select one of the following option");

                for (int i = 0; i < materialPackageTypes.GetLength(0); i++)
                {
                    Console.WriteLine((i+1).ToString() + "." + materialPackageTypes[i, 0]);
                }

                choiceInput = readUserChoice("", 1, materialPackageTypes.GetLength(0));

                materialInfo.materialType = materialPackageTypes[choiceInput - 1, 0];
                materialInfo.packaging = materialPackageTypes[choiceInput - 1, 1];

                materialInfo.format = readString("Format");
                materialInfo.audioFormat = readString("AudioFormat(Dolby, Dolby digital, MPEG-1,PCM or DTS)");
                materialInfo.runTime = TimeSpan.Parse(readString("Run Time (hours:mins:secs)"));
                materialInfo.releaseDate = Convert.ToDateTime(readString("Release Date (yyyy-MM-dd)"));
                materialInfo.launguage = readString("Language");
                Console.Write("Retail Price:");
                materialInfo.retailPrice = (float)Convert.ToDouble(Console.ReadLine());
                materialInfo.subTitles = readString("SubTitles");
                materialInfo.frameAspect = readString("FrameAspect");
            }
            catch(Exception ex)
            {
                //mostly failure will be occurred in conversions
                Console.WriteLine(ex.Message);                
            }
            return materialInfo;
        }

        public MaterialModel displayAddMaterailInstrucitons(MaterialModel materialInfo)
        {
            Console.WriteLine("\nPlease Enter the following details of the new materail info");

            materialInfo = readMaterialInfo(materialInfo);
            
            materialInfo.addedDate = System.DateTime.Now.ToString("yyyy-MM-dd");
            materialInfo.addedBy = readString("AddedBy");

            return materialInfo;
        }

        public MaterialModel userSearchInstrucitons(MaterialModel materialInfo)
        {
            int userInputChoice;

            Console.WriteLine("\nPlease choose one of the following details for material search");
        
            userInputChoice = readUserChoice("1. Project Title \n2. Material Number \n3. Added Date \n4. Material Type",1,4);

            if (userInputChoice == 1)
            {
                materialInfo.projectTitle = readString("\nEnter Project Title");
            }
            else if (userInputChoice == 2)
            {
                materialInfo.IdentificationNumber = int.Parse(readString("\nEnter Material Identification Number"));
            }
            else if (userInputChoice == 3)
            {
                materialInfo.addedDate = readString("\nEnter Date for search in format (yyyy-MM-dd)");
            }
            else if (userInputChoice == 4)
            {
                materialInfo.materialType = readString("\nEnter Material Type");
            }
            return materialInfo;
        }

        public MaterialModel displayUpdateMaterailInstrucitons(MaterialModel materialInfo)
        {
            Console.WriteLine("\nNote: Please search for material to make sure it is exist before Updating.");

            Console.WriteLine("\nPlease Enter the following details to update the materials info");

            materialInfo = readMaterialInfo(materialInfo);

            materialInfo.IdentificationNumber = int.Parse(readString("Enter Material Identification Number"));

            return materialInfo;
            
        }

        public int displayDeleteMaterailInstrucitons()
        {
            int userInputVal = 0;

            Console.WriteLine("\nNote: Please search for material to make sure it is exist before deleting.");

            userInputVal = int.Parse(readString("Please Enter Material Identification Number to delete"));

            return userInputVal;
        }
    }
}
