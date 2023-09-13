using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    public interface IAppointmentService
    {
        Appointment BookAppointment(Appointment appointment);
        Appointment CancelAppointment(Appointment appointment);
        bool CheckAvailability(Appointment appointment);
    }
}
