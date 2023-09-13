using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Repositories;
using DoctorClinicApplication.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ClinicTest
{
    public class DoctorServiceTest
    {



        ClinicContext context;
        //Gets executed for every test
        [SetUp]
        public void Setup()
        {
            var dbContextOption = new DbContextOptionsBuilder<ClinicContext>().UseInMemoryDatabase(databaseName: "dbDummyClinic").Options;
            context = new ClinicContext(dbContextOption);
        }





        [Test]
        public void AddTest()
        {
            //Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);
            IDoctorService doctorService = new DoctorService(doctorRepository);
            var doctor = new Doctor { Id = 1, Name = "Pavan", Experience = 3, Speciality = "Dentist", Phone = "9874563210", Email = "pavan@gmail.com", Pic = "/images/Pic2.jpg" };
            var addedDoctor = doctorService.Add(doctor);

            //Action
            var result = new Doctor { Id = 1, Name = "Pavan", Experience = 3, Speciality = "Dentist", Phone = "9874563210", Email = "pavan@gmail.com", Pic = "/images/Pic2.jpg" };
            //Assert
            Assert.AreEqual(result, addedDoctor);
        }
        [Test]
        public void GetAllDoctorsTest()
        {
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);
            var doctor = new Doctor { Id = 2, Name = "Babu", Experience = 2, Speciality = "Radiologist", Phone = "90123654789", Email = "babu@gmail.com", Pic = "images/Pic3.jpg" };
            doctorRepository.Add(doctor);


            IDoctorService patientservice = new DoctorService(doctorRepository);
            var expectedresult = new Doctor { Id = 2, Name = "Babu", Experience = 2, Speciality = "Radiologist", Phone = "90123654789", Email = "babu@gmail.com", Pic = "images/Pic3.jpg" };
            Assert.AreEqual(doctor, expectedresult);
        }



    }
}
        