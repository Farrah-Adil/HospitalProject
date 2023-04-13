using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class LabEntity
    {
        [Key]

        public  int LabId { get; set; }
  
        public string LabName { get; set; }
        public string LabAdd { get; set; }
        public string LabPhone { get; set; }
        public string LabEmail { get; set; }
        





    }
}
