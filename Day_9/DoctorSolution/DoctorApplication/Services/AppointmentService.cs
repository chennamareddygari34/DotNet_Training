using System.Numerics;
using DoctorApplication.Exceptions;
using DoctorApplication.Interfaces;
using DoctorApplication.Migrations;
using DoctorApplication.Models;
using DoctorApplication.Repositories;

namespace DoctorApplication.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<int, Models.Appointment> _repository;
        private readonly DoctorRepository doctorRepository;

        public Models.Appointment BookAppointment(Models.Appointment appointment)
        {
            if (appointment != null)
            {
                Models.Doctor doctor = doctorRepository.Get(appointment.DoctorId);
                if (doctor != null)
                {
                    var appointments = _repository.GetAll();
                    var existingAppointment = appointments.Where(I => I.AppointmentNumber == appointment.DoctorId && I.Date == appointment.Date).ToList();
                    if (existingAppointment == null)
                    {
                        _repository.Create(appointment);
                        return appointment;
                    }
                    else
                    {
                        throw new DoctorStackEmptyException();
                    }
                }
            }
            var result = _repository.Create(appointment);
            return result;
        }

        public Models.Appointment CancelAppointment(Models.Appointment appointment)
        {
            var val = _repository.Get(appointment.AppointmentNumber);
            val = _repository.Delete(appointment.AppointmentNumber);
            return val;
        }

        public bool CheckAvailability(Models.Appointment appointment)
        {
            if (appointment != null)
            {
                Models.Doctor doctor = doctorRepository.Get(appointment.DoctorId);
                if (doctor != null)
                {
                    var appointments = _repository.GetAll();
                    var existingAppointment = appointments.Where(I => I.DoctorId == appointment.DoctorId && I.Date == appointment.Date).ToList();
                    if (existingAppointment == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new InvalidUserException();
                }
            }
            return true;
        }
    }
}
