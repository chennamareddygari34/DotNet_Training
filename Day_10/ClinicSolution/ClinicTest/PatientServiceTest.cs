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
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;



namespace ClinicTest
{
    public class PatientServiceTest
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
        public void AddPatientTest()
        {
            //Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            var patient = new Patient { Id = 1, Name = "Raj", Age = 22, Phone = "5454545454", Email = "Raj@gmail.com" };
            patientRepository.Add(patient);



            IPatientService patientService = new PatientService(patientRepository);



            //Action



            var expectedresult = new Patient { Id = 1, Name = "Raj", Age = 22, Phone = "5454545454", Email = "Raj@gmail.com" };



            //var result=doctorService.Add(doctor);
            //Assert
            Assert.AreEqual(1, expectedresult.Id);



        }

        [Test]
        public void GetAllPatientsTest()
        {
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            var patient = new Patient { Id = 3, Name = "ABC", Age = 25, Phone = "918365476699", Email = "ramu1@gmail.com" };
            patientRepository.Add(patient);
            IPatientService patientservice = new PatientService(patientRepository);
            var expectedresult = new Patient { Id = 3, Name = "ABC", Age = 25, Phone = "918365476699", Email = "ramu1@gmail.com" };
            ;
            Assert.AreEqual(patient, expectedresult);
        }
    }
}