using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class HospitalEntity
    {


        [Key]

        public int HospitalId { get; set; }
        public string Name { get;set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }   
}
