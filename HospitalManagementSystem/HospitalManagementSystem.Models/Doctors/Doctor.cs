using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Doctor:BaseEntity
    {
       
        [Required]
        [MaxLength(100)]
        public  string Name { get; set; }
        public string? Specialization { get; set; }
        public string? ImageURL { get; set; }
        [ForeignKey("SpecialtyLevel")]
        public int SpecialtyLevel {  get; set; }
        [MaxLength(11)]
        [Required]
        public  string Phone { get; set; }
        [Required]
        [ForeignKey("Department")]
        public  int DepartmentID { get; set; }
        public  virtual Department Department { get; set; }
        public virtual SpecialityLevel? SpecialityLevel { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public virtual ICollection<Appointment> Appointments { get; set; }=new List<Appointment>();
    }
}