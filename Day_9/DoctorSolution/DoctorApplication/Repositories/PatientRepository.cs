using DoctorApplication.Contexts;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;

namespace DoctorApplication.Repositories
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly DoctorContext _context;
        public Patient Create(Patient entity)
        {
            _context.patients.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Patient Delete(int key)
        {
            var patient = Get(key);
            _context.patients.Remove(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient Get(int key)
        {
            var patient = _context.patients.FirstOrDefault(d => d.PatientId == key);
            return patient;
        }

        public object? Get(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Patient> GetAll()
        {
            return _context.patients.ToList();
        }

        public Patient Update(Patient entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
