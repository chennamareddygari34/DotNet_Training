using System.Diagnostics;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApplication.Controllers
{
    public class DoctorController : Controller
    {

        private readonly IRepository<int, Doctor> _repository;

        List<Doctor> doctors = new List<Doctor>();

        public DoctorController(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            _repository.Create(doctor);
            return RedirectToAction("Index");
        }
        #region update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var doctor = _repository.Get(id);
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Update(int id, Doctor doctor)
        {
            ViewBag.Message = "";
            try
            {
                _repository.Update(doctor);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                ViewBag.Message = "doctor not found";
            }
            return View(doctor);
        }
        #endregion
    }
}
