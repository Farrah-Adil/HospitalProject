using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class PharmacyEntity
    {
        [Key]
        public int PharmacyId { get; set; }
    
        public string PharName { get; set; }
        public string PharAdd { get; set; }
        public string PharPhone { get; set;}
        public string PharEmail { get; set; }

       

    }
}
