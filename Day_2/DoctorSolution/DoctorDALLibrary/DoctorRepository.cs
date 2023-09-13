using DoctorModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace DoctorDALLibrary
{
    public class DoctorRepository : DRepository<int, Doctor>
    {
        List<Doctor> doctors
            = new List<Doctor>();
        public Doctor Add(Doctor item)
        {
            if (item == null)
                throw new ArgumentNullException("No doctor available");
            item.Id = GeterateIndex();
            doctors.Add(item);
            return item;
        }

        private int GeterateIndex()
        {
            int id = doctors.Count;
            return ++id;
        }

        public Doctor Delete(int key)
        {
            Doctor doctor = GetById(key);
            doctors.Remove(doctor);
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            if (doctors.Count == 0)
                throw new DoctorsNotAvailableException();
            return doctors;
        }

        public Doctor GetById(int key)
        {
            Doctor doctor = doctors.FirstOrDefault(p => p.Id == key);
            if (doctor == null)
                throw new InvalidOperationException("No doctor with id " + key);
            return doctor;
        }

        public Doctor Update(Doctor item)
        {
            Doctor doctor = GetById(item.Id);
            doctor.Name = item.Name;

            doctor.YearOfExperience = item.YearOfExperience;
            doctor.Specialization = item.Specialization;
            return doctor;
        }
    }
}