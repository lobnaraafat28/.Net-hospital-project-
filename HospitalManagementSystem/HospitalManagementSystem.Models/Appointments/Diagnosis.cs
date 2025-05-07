using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Appointments
{
    public class Diagnosis:BaseEntity
    {
        [Required]
        [MaxLength(600)]
        public string? Description { get; set; }
       
        public virtual ICollection<History>? Histories { get; set; }

    }
}