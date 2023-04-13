using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class PatientEntity
    {
        [Key]


        public int PtId { get; set; }
        public string Name { get; set;}
        public string Age { get; set;}
        public string Address { get; set; }
        public string Gender{ get; set; }
        public int HosId { get; set; }
        public int  DepId { get; set;}
        public string HosName { get; set; }
        public string DepName { get; set;}

    }
}
