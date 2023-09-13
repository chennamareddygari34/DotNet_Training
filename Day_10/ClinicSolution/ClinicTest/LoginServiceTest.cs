using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Repositories;
using DoctorClinicApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicTest
{
    public class Tests
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
        public void LoginTest()
        {
            //Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            var patient = new Patient { Id = 1, Name = "Raj", Age = 22, Phone = "5454545454", Email = "Raj@gmail.com" };
            patientRepository.Add(patient);
            ILoginService loginService = new LoginService(patientRepository);
            //Action
            var result = loginService.Login(new LoginDTO { Id = 1, Password = "5454545454" });
            //Assert
            Assert.AreEqual(1, result.Id);
        }
    }
}