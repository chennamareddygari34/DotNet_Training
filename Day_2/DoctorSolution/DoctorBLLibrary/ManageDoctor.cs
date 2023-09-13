using DoctorDALLibrary;
using DoctorModelLibrary;

namespace DoctorBLLibrary
{
    public class ManageDoctor
    {
        private static readonly DoctorRepository doctorRepository = new DoctorRepository();
        DRepository<int, Doctor> repository = (DRepository<int, Doctor>)doctorRepository;

        public ICollection<Doctor> GetDoctor()
        {
            return repository.GetAll();
        }

        public ICollection<Doctor> GetDoctorByType(string type)
        {
            var Doctors = GetDoctor();
            if (type == "General" || type == "neurologist" || type == "Oncologist" || type == "Urologist")
            {
                var typeSpecificDoctor = Doctors.Where(p => p.Specialization == type).ToList();
                if (typeSpecificDoctor.Count == 0)
                    throw new DoctorsNotAvailableException();
                return typeSpecificDoctor;
            }
            throw new InvalidDoctorException();
        }

        public ICollection<Doctor> GetPizzasByYearOfExperience(int min, int max)
        {
            var Doctors = GetDoctor();
            if (min >= 00 || max > 0)
            {
                var experienceInRange = Doctors.Where(p => p.YearOfExperience >= min && p.YearOfExperience <= max).ToList();
                if (experienceInRange.Count == 0)
                    throw new DoctorsNotAvailableException();
                return experienceInRange;
            }
            throw new InvalidDoctorException();
        }

        public Doctor AddANewDoctor(Doctor doctor)
        {
            repository.Add(doctor);
            return doctor;
        }

        public object GetDoctorBySpecialization(string? type)
        {
            throw new NotImplementedException();
        }
    }
}
