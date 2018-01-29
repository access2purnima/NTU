using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrekStarFilmManagementSystem
{
    public class ProjectModel
    {
        public int IdentificationNumber { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string genre { get; set; }
        public DateTime releaseDate { get; set; }
        public string filmLocations { get; set; }
        public string launguage { get; set; }
        public TimeSpan runtime { get; set; }
        public string keywords { get; set; }
        public float weeklyTicketPrice { get; set; }
        public string addedDate { get; set; }
        public string addedBy { get; set; }        
    }

    public class MaterialModel
    {
        public int IdentificationNumber { get; set; }
        public string title { get; set; }
        public string projectTitle { get; set; }
        public string materialType { get; set; }  
        public string format { get; set; }
        public string audioFormat { get; set; }
        public TimeSpan runTime { get; set; }
        public DateTime releaseDate { get; set; }        
        public string launguage { get; set; }
        public float retailPrice { get; set; }
        public string subTitles { get; set; }
        public string frameAspect { get; set; }
        public string packaging { get; set; }             
        public string addedDate { get; set; }
        public string addedBy { get; set; }
    }
}
