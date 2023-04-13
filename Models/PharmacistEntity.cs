using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class PharmacistEntity
    {
        [Key]

        public int pharmacistId { get; set; }

        public string Name { get; set; }    
        public string Age { get; set; }
        public string Gender { get; set; }  
        public string PhoneNo { get; set; }
        public int PharmacyId { get; set; }
        public string PharmacyName { get;set; }




    }
}
