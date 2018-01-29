using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrekStarFilmManagementSystem
{
    class MaterialCotrollerMain
    {      
        public static void Main()
        {
            Boolean isAdmin;

            string UserChoice = "";
            string returnOutput = "";

            IMaterialDatabaseActivity projec = new MaterialDatabaseActivitySQL();
            MaterialModel materialInfo = new MaterialModel();
            materialsView projView = new materialsView();

            List<MaterialModel> lstMaterialsModel;

            isAdmin = projView.initialse();

            UserChoice = projView.userOptions(isAdmin);

            if (UserChoice == "Search")
            {
                materialInfo = projView.userSearchInstrucitons(materialInfo);
                lstMaterialsModel = projec.Search(materialInfo);
                projView.displayMaterialList(lstMaterialsModel);
            }
            else if (UserChoice == "Add")
            {
                materialInfo = projView.displayAddMaterailInstrucitons(materialInfo);
                returnOutput = projec.Add(materialInfo);

                if (returnOutput == "")
                {
                    Console.WriteLine("New Material Added Sucessfully");
                }
                else
                {
                    Console.WriteLine(returnOutput);
                }
            }
            else if (UserChoice == "Update")
            {
                projView.displayUpdateMaterailInstrucitons(materialInfo);
                returnOutput = projec.Update(materialInfo);

                if (returnOutput == "")
                {
                   Console.WriteLine("Material updated Sucessfully");
                }
                else
                {
                    Console.WriteLine(returnOutput);
                }
            }
            else if (UserChoice == "Delete")
            {
                materialInfo.IdentificationNumber = projView.displayDeleteMaterailInstrucitons();
                returnOutput = projec.Delete(materialInfo);

                if (returnOutput == "")
                {
                    Console.WriteLine("Material deleted Sucessfully");
                }
                else
                {
                    Console.WriteLine(returnOutput);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
