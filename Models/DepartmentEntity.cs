using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject.Models
{
    public class DepartmentEntity
    {
        [Key]
        
        public int DepId { get; set; }
       
        public string DepName { get; set; }
        
        public string DepHead { get; set; }
       
        public string DepPhone { get; set; }
        
        public string DepEmail { get; set; }
       
        public int HosId { get; set; }
        
        [NotMapped]
        public string HosName { get; set;}
    }
}

       
    








    









