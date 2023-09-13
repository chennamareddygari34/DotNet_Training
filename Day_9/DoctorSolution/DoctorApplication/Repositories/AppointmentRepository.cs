using DoctorApplication.Contexts;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;

namespace DoctorApplication.Repositories
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly DoctorContext _context;
        public Appointment Create(Appointment entity)
        {
            _context.appointment.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Appointment Delete(int key)
        {
            var apmt = Get(key);
            _context.appointment.Remove(apmt);
            _context.SaveChanges();
            return apmt;
        }

        public Appointment Get(int key)
        {
            var apmt = _context.appointment.FirstOrDefault(d => d.AppointmentNumber == key);
            return apmt;
        }

        public object? Get(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Appointment> GetAll()
        {
            return _context.appointment.ToList();
        }

        public Appointment Update(Appointment entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

