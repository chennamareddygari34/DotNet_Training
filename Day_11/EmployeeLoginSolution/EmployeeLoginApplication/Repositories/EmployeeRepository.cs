using System.Numerics;
using EmployeeLoginApplication.Context;
using EmployeeLoginApplication.Exceptions;
using EmployeeLoginApplication.Interfaces;
using EmployeeLoginApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoginApplication.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public Employee Add(Employee entity)
        {
            _context.employees.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Employee Delete(int key)
        {
            var employee = GetById(key);
            if (employee == null)
                throw new NoSuchEntityException("Employee");
            _context.employees.Remove(employee);
            _context.SaveChanges();
            return employee;
        }

        public ICollection<Employee> GetAll()
        {
            var employees = _context.employees;
            if (employees.Count() == 0)
                throw new NoEmployeesAreAvailable();
            return employees.ToList();
        }

        public Employee GetById(int key)
        {
            var employee = _context.employees.SingleOrDefault(d => d.Id == key);
            if (employee != null)
                return employee;
            throw new NoSuchEntityException("Employee");
        }

        public Employee Update(Employee entity)
        {
            var employee = GetById(entity.Id);
            if (employee != null)
            {
                _context.Entry<Employee>(employee).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new NoSuchEmployeeException();
        }
    }
}
