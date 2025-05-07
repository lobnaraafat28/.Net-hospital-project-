using HospitalManagementSystem.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Users
{
    public class User:BaseEntity
    {

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? PasswordHash { get; set; }
        public byte[]? StoredSalt{ get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
       

       
    }
}