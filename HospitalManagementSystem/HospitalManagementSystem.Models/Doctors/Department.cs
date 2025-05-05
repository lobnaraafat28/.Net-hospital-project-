using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public Status Status { get; set; }

        [Required]
        [MaxLength(600)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}