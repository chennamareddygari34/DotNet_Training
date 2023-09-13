using DoctorApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApplication.Contexts
{
    public class DoctorContext : DbContext
    {
        public DoctorContext(DbContextOptions options) : base(options)//constructor chaining
        {

        }
        public DbSet<Doctor> doctors { get; set; }//doctors

        public DbSet<Patient> patients { get; set; } //patients
        public DbSet<Appointment> appointment { get; set; } //appointment

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(apt => new { apt.DoctorId, apt.PatientID });

            modelBuilder.Entity<Doctor>().HasData(

               new Doctor { Id = 1, Name = "PavankalyanReddy", Experience = 2, Speciality = "Orthopedics", Phone = "8121288262", Email = "pavan@gamil.com" },

               new Doctor { Id = 2, Name = "Babu", Experience = 5, Speciality = "Dermatology", Phone = "9989355384", Email = "babu@gamil.com" }

               );



            modelBuilder.Entity<Patient>().HasData(

               new Patient { PatientId = 1, PatientName = "Raju", PatientAge = 23, Email = "raju@gmail.com" },

               new Patient { PatientId = 2, PatientName = "Ramu", PatientAge = 24, Email = "ramu@gmail.com" }

               );



            modelBuilder.Entity<Appointment>().HasData(

               new Appointment { AppointmentNumber = 1, DoctorId = 1, PatientID = 1, Date = "05-09-2023" },

               new Appointment { AppointmentNumber = 2, DoctorId = 2, PatientID = 2, Date = "19-10-2023" }

               );
        }
    }
}
