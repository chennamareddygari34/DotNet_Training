using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;



namespace DoctorClinicApplication.Interfaces
{
    public interface IPatientService : IAddingEntity<Patient>
    {
        public Patient UpdatePhone(PatientPhoneDTO patientPhone);
        public IList<Patient> GetAllPatients();
    }
}