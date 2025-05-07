using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Base;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Schedule:BaseEntity
    {
       
        public DayOfWeek Day { get; set; }  

        public TimeSpan StartTime { get; set; }  
        public TimeSpan EndTime { get; set; }    

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}