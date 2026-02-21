using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    /* 
    public class PatientReport
    {
        public int Id { get; set; }
        public string Diagnose { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    }
    */
    public class PatientReport
    {
        public int Id { get; set; }
        public string Diagnose { get; set; }

        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }   // navigation property

        public string PatientId { get; set; }
        public ApplicationUser Patient { get; set; }  // navigation property
    }

}
