using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    public interface IPatientService
    {
        Patient AddPatient(Patient patient);
        Patient UpdatePatientPhone(Patient patient);
    }
}
