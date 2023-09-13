using DoctorClinicApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApplication.Contexts
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Pavan", Experience = 3, Speciality = "Dentist", Phone = "9874563210", Email = "pavan@gmail.com", Pic = "/images/Pic2.jpg" },
                new Doctor { Id = 2, Name = "Babu", Experience = 2, Speciality = "Radiologist", Phone = "90123654789", Email = "babu@gmail.com", Pic = "/images/Pic3.jpg" }
          );
        
        modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Raj", Age = 22, Phone = "5454545454", Email = "Raj@gmail.com" },
                new Patient { Id = 2, Name = "Tej", Age = 56, Phone = "9898989898", Email = "Tej@gmail.com" }
                );
        }
    }
}