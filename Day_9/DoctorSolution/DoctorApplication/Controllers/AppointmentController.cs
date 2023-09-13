using Microsoft.AspNetCore.Mvc;

namespace DoctorApplication.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
