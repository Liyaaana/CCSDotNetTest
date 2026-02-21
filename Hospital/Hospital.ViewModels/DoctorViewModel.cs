using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class DoctorViewModel
    {
        public string Id { get; set; }   // Assuming your DoctorId is string (from Identity UserId)
        public string Name { get; set; }
    }
}
