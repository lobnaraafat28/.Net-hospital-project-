using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Enums;
using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class Appointment : BaseEntity
    {

        [Required]
        public DateTime AppointmentDateTime { get; set; }

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

        public virtual Prescription? Prescription { get; set; }

    }
}