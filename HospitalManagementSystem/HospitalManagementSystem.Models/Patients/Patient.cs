using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Patients
{
    public class Patient:BaseEntity
    {

        [Required]
        public  string Name { get; set; }
        public string? Address { get; set; }
        public Gender GenderType { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(11)]

        public  string PhoneNumber { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }= new HashSet<Appointment>();
        public virtual ICollection<History> Histories { get; set; }= new HashSet<History>();
    }
}