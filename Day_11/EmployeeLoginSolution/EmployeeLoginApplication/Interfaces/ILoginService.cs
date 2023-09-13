using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;

namespace EmployeeLoginApplication.Interfaces
{
    public interface ILoginService
    {
        public Employee Login(LoginDTO loginDTO);
    }
}
