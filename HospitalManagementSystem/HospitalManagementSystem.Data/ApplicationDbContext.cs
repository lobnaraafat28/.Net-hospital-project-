using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Contacts;
using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Patients;
using HospitalManagementSystem.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HospitalManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<ContactUs> ContactUsMessages { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany(dep => dep.Doctors)
                .HasForeignKey(d => d.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Doctor)
                .WithMany(d => d.Schedules)
                .HasForeignKey(s => s.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Schedule)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ScheduleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Prescriptions)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.History)
                .WithMany(h => h.Prescriptions)
                .HasForeignKey(p => p.HistoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<History>()
                .HasOne(h => h.Patient)
                .WithMany(p => p.Histories)
                .HasForeignKey(h => h.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<History>()
                .HasOne(h => h.Diagnosis)
                .WithMany(d => d.Histories)
                .HasForeignKey(h => h.DiagnosisID)
                .OnDelete(DeleteBehavior.Restrict);

          
            
           
            base.OnModelCreating(modelBuilder);
            

           
       
        }
    }
}