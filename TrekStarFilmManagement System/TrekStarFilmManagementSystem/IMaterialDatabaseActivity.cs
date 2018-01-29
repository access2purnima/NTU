using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrekStarFilmManagementSystem
{
    public interface IMaterialDatabaseActivity
    {
        string Add(MaterialModel MaterialInfo);

        List<MaterialModel> Search(MaterialModel MaterialInfo);

        string Update(MaterialModel MaterialInfo);

        string Delete(MaterialModel MaterialInfo);  
    }
}
