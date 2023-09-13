
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _employeeService.GetAllEmployees();
            if (result == null)
            {
                return NotFound("No employees are there at this moment");
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.AddANewEmployee(employee);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }
        [HttpPut("UpdateStatus")]
        public ActionResult PutChangeStatus(int id)
        {
            try
            {
                var result = _employeeService.ToggleEmployeeStatus(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("UpdateMaxMin")]

        public ActionResult PutChangesStatus(float min, float max)
        {
            try
            {

                var result = _employeeService.GemEmployeesInASalaryRange(min, max);
                if (result == null)

                return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("Salary")]

        public ActionResult UpdateSalary(EmployeeSalaryDTO empsalary)
        {
            try
            {

                var result = _employeeService.UpdateEmployeeSalary(empsalary);
                if (result == null)

                return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Phone")]

        public ActionResult UpdatePhone(EmployeePhoneDTO empphone)
        {
            try
            {

                var result = _employeeService.UpdateEmployeePhone(empphone);
                if (result == null)
                return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}
