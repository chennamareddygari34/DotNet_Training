using System.Numerics;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;

namespace EmployeeLoginApplication.Interfaces
{
    public interface IEmployeeService
    {
        public IList<Employee> GetAllEmployees();
        public Employee UpdatePhone(EmployeeDTO employeeDTO);
        public Employee Add(Employee employee);
    }
}
