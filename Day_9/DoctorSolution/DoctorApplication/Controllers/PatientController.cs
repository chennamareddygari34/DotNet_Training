using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApplication.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRepository<int, Patient> _repository;

        List<Patient> doctors = new List<Patient>();

        public PatientController(IRepository<int, Doctor> repository)
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            _repository.Create(patient);
            return RedirectToAction("Index");
        }
    }
}
