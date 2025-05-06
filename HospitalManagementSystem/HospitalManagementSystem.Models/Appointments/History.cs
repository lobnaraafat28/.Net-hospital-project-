using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        [ForeignKey("Patient")]
        [Required]
        public int PatientID { get; set; }
        [Required]
        public virtual Patient Patient { get; set; }

        [ForeignKey("Diagnosis")]
        [Required]
        public int DiagnosisID { get; set; }
        [Required]
        public Diagnosis Diagnosis { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }
    }
}