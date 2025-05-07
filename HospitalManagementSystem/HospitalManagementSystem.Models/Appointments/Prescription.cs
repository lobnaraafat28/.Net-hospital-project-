using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Enums;
using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class Prescription:BaseEntity
    {
       
        public DateTime Date { get; set; }
      
        public virtual ICollection<PrescriptionImage> PrescriptionImages { get; set; }
        [ForeignKey("Patient")]
        [Required]
        public int PatientID { get; set; }
        [Required]
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        [Required]
        public int DoctorID { get; set; }
        [Required]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("History")]
        [Required]
        public int HistoryID { get; set; }
        public History? History { get; set; }

        [ForeignKey("Appointment")]
        [Required]
        public int AppointmentID { get; set; }
        [Required]
        public Appointment Appointment { get; set; }
    }
}