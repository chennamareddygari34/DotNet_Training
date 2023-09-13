using System.Numerics;
using DoctorApplication.Exceptions;
using DoctorApplication.Interfaces;
using DoctorApplication.Migrations;
using DoctorApplication.Models;

namespace DoctorApplication.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Models.Patient> _repository;
        public Models.Patient AddPatient(Models.Patient patient)
        {
            var result = _repository.Create(patient);
            return result;
        }

        public Models.Patient UpdatePatientPhone(Models.Patient patient)
        {
            var val = _repository.Get(patient.PatientId);
            if (val != null)
            {
                val.Email = patient.Email;
                _repository.Update(val);
                return val;
            }
            else
            {
                throw new InvalidUserException();
            }
        }
    }
}
