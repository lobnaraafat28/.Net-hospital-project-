using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        public DayOfWeek Day { get; set; }  

        public TimeSpan StartTime { get; set; }  
        public TimeSpan EndTime { get; set; }    
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public Status Status { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}