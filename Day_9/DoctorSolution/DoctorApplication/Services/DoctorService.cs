using DoctorApplication.Exceptions;
using DoctorApplication.Interfaces;
using DoctorApplication.Migrations;
using DoctorApplication.Models;

namespace DoctorApplication.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Models.Doctor> _repository;

        public Models.Doctor AddDoctor(Models.Doctor doctor)
        {
            var result = _repository.Create(doctor);
            return result;

        }
        public Models.Doctor UpdateDoctorByExp(Models.Doctor doctor)
        {
            var val = _repository.Get(doctor.Id);
            if (val == null)
                throw new DoctorStackEmptyException();
            val.Experience = doctor.Experience;
            val = _repository.Update(val);
            return val;
        }
        public Models.Doctor UpdateDoctorBySpec(Models.Doctor doctor)
        {
            var val = _repository.Get(doctor.Id);
            if (val == null)
                throw new DoctorStackEmptyException();
            val.Speciality = doctor.Speciality;
            val = _repository.Update(val);
            return val;
        }

        public Models.Doctor UpdateDoctorPhone(Models.Doctor doctor)
        {
            var val = _repository.Get(doctor.Id);
            if (val != null)
            {
                val.Phone = doctor.Phone;
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
