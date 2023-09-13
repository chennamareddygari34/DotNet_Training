using System.Numerics;
using EmployeeLoginApplication.Interfaces;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;

namespace EmployeeLoginApplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }

        public Employee Add(Employee entity)
        {
            var employee = _repository.Add(entity);
            return employee;
        }
        public IList<Employee> GetAllEmployees()
        {
            return _repository.GetAll().ToList();
        }
        public Employee UpdatePhone(EmployeeDTO employeeDTO)
        {
            var emp = _repository.GetById(employeeDTO.Id);
            emp.Phone = employeeDTO.Phone;
            _repository.Update(emp);
            return emp;
        }
    }
}
