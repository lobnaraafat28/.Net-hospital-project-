using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Enums;
using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public Status Status { get; set; }
        public List<string>? ImageURLs { get; set; }
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