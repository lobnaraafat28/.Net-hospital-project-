using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Contacts
{
    public class ContactUs
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(600)]
        public string? Address { get; set; }

        [Required]
        public required string Name { get; set; }
        public Status Status { get; set; }
        [MaxLength(11)]

        public string? Phone { get; set; }
    }
}