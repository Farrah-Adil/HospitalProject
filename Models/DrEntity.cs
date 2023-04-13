using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class DrEntity
    {
        [Key]
        public int DrId { get; set; }

        public string DrName { get; set; }  

        public string DrSpecialty { get; set; }
        public string DrLicencesNo{ get; set; }
        public int HosId { get; set; }
        public int DepId { get; set;}





    }
}
