using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models.Doctors
{
    public class SpecialityLevel
    {
        public required string Name { get; set; }
        public int Id { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
