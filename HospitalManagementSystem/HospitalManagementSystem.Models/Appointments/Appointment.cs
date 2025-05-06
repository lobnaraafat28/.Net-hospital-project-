using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Enums;
using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }
        public Status Status { get; set; }

        [ForeignKey("Patient")]
        [Required]
        public int PatientID { get; set; }
        [Required]
        public  virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        [Required]
        public int DoctorID { get; set; }
        [Required]
        public  virtual Doctor Doctor { get; set; }

        [ForeignKey("Schedule")]
        [Required]  
        public int ScheduleID { get; set; }
        public  virtual Schedule Schedule { get; set; }

        public virtual Prescription? Prescriptions { get; set; }

    }
}