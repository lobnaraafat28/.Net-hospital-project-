using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Department:BaseEntity
    {
       

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(600)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}