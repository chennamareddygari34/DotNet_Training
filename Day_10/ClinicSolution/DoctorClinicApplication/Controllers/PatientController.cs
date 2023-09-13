using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using Microsoft.AspNetCore.Mvc;



namespace DoctorClinicApplication.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<Patient> _logger;



        public PatientController(IPatientService patientService, ILogger<Patient> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                patients = _patientService.GetAllPatients().ToList();
                return View(patients);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogInformation("There were no patients");
            }
            return View(patients);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            try
            {
                var myDoctor = _patientService.Add(patient);
                _logger.LogInformation("Created patient record");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to add patient ");
            }
            return View();
        }
    }
}