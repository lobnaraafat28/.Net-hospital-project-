using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models.Doctors
{
    public class SpecialityLevel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
       
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
