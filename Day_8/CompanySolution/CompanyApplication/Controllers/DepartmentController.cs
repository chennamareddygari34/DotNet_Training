using CompanyApplication.Interfaces.CompanyApplication.Interfaces;
using CompanyApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using System.Diagnostics;

using CompanyApplication.Interfaces;

using CompanyApplication.Models;

using Microsoft.AspNetCore.Mvc;

 

namespace CompanyApplication.Controllers

{

    public class DepartmentController : Controller

    {

        private readonly IRepository<int, Department> _repository;

        List<Department> departments = new List<Department>();



        public DepartmentController(IRepository<int, Department> repository)

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

        public IActionResult Create(Department department)

        {

            _repository.Add(department);

            return RedirectToAction("Index");

        }



        [HttpGet]

        public IActionResult Delete(int id)

        {

            var department = _repository.Get(id);

            return View(department);

        }



        public IActionResult Delete(int id, Department department)

        {

            ViewBag.Message = "";

            try

            {

                _repository.Delete(id);

                return RedirectToAction("Index");

            }

            catch (Exception e)

            {

                Debug.WriteLine(e.Message);

                ViewBag.Message = "Unable to delete Department.";

            }

            return View(department);

        }



        #region update

        [HttpGet]

        public IActionResult Update(int id)

        {

            var department = _repository.Get(id);

            return View(department);

        }

        [HttpPost]

        public IActionResult Update(int id, Department department)

        {

            ViewBag.Message = "";

            try

            {

                _repository.Update(department);

                return RedirectToAction("Index");

            }

            catch (Exception e)

            {

                Debug.WriteLine(e.Message);

                ViewBag.Message = "department not found";

            }

            return View(department);

        }

        #endregion

    }

}