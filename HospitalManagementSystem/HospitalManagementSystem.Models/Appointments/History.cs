using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class History:BaseEntity
    {
       

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