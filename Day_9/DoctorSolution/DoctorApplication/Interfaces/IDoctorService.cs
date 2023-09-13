using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    public interface IDoctorService
    {
        Doctor AddDoctor(Doctor doctor);
        Doctor UpdateDoctorByExp(Doctor doctor);
        Doctor UpdateDoctorBySpec(Doctor doctor);
        Doctor UpdateDoctorPhone(Doctor doctor);
    }
}
