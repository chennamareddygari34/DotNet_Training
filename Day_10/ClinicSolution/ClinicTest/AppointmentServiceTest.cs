using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Repositories;
using DoctorClinicApplication.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ClinicTest
{

    public class AppointmentServiceTest
    {
        ClinicContext context;





        [SetUp]
        public void Setup()
        {
            var dbContextOption = new DbContextOptionsBuilder<ClinicContext>().UseInMemoryDatabase(databaseName: "dbDummyClinic").Options;
            context = new ClinicContext(dbContextOption);
        }
        [Test]
        public void AddAppointmentTest()
        {



            IRepository<int, Appointment> appointmentRepository = new AppointmnetRepository(context);
            DateTime dt2 = new DateTime(2023, 06, 7, 5, 10, 20);
            Appointment appointment = (new Appointment { AppointmentNumber = 1, PatientId = 1, DoctorId = 1, AppointmentDateTime = dt2 });
            appointmentRepository.Add(appointment);
            IAppointmentService appointmentservice = new AppointmentService(appointmentRepository);
            var result = new Appointment { AppointmentNumber = 1, PatientId = 1, DoctorId = 1, AppointmentDateTime = dt2 };
            Assert.AreEqual(1, result.AppointmentNumber);
        }
       

        [Test]

        public void GetAllAppointmentsTest()
        {
            IRepository<int, Appointment> appointmentRepository = new AppointmnetRepository(context);

            DateTime dt2 = new DateTime(2023, 06, 8, 4, 20, 10);
            Appointment appointment = (new Appointment { AppointmentNumber = 2, PatientId = 2, DoctorId = 1, AppointmentDateTime = dt2 });
            appointmentRepository.Add(appointment);




            DateTime dt1 = new DateTime(2023, 06, 8, 4, 30, 10);
            Appointment appointment1 = (new Appointment { AppointmentNumber = 3, PatientId = 3, DoctorId = 1, AppointmentDateTime = dt1 });
            IAppointmentService appointmentservice = new AppointmentService(appointmentRepository);
            appointmentRepository.Add(appointment1);



            DateTime dt3 = new DateTime(2023, 06, 7, 5, 30, 10);
            Appointment appointment2 = (new Appointment { AppointmentNumber = 4, PatientId = 4, DoctorId = 1, AppointmentDateTime = dt3 });
            IAppointmentService appointmentservice2 = new AppointmentService(appointmentRepository);
            appointmentRepository.Add(appointment2);



            var result = new Appointment { AppointmentNumber = 2, PatientId = 2, DoctorId = 1, AppointmentDateTime = dt2 };

            Assert.AreEqual(result, appointment); ;
        }



    }
}