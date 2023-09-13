using DoctorApplication.Contexts;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;

namespace DoctorApplication.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DoctorContext _context;

        public DoctorRepository(DoctorContext context)
        {
            _context = context;
        }

        public Doctor Create(Doctor entity)
        {
            _context.doctors.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Doctor Delete(int key)
        {
            var doctor = Get(key);
            _context.doctors.Remove(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor Get(int key)
        {
            var doctor = _context.doctors.FirstOrDefault(d => d.Id == key);
            return doctor;
        }

        public object? Get(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Doctor> GetAll()
        {
            return _context.doctors.ToList();
        }

        public Doctor Update(Doctor entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
