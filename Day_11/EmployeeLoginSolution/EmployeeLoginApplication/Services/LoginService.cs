using EmployeeLoginApplication.Exceptions;
using EmployeeLoginApplication.Interfaces;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;

namespace EmployeeLoginApplication.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int, Employee> _repository;

        public LoginService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }
        public Employee Login(LoginDTO loginDTO)
        {
            try
            {
                var employee = _repository.GetById(loginDTO.Id);
                if (employee.Phone == loginDTO.Password)
                    return employee;
            }
            catch (NoSuchEntityException e)
            {
                throw new InvalidCredentialsException();
            }
            throw new InvalidCredentialsException();
        }
    }
}
