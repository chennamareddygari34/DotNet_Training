using System.ComponentModel.DataAnnotations;

namespace EmployeeLoginApplication.Models.DTOs
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Employee Id is manditory")]
        public int Id { get; set; }
        [Required(ErrorMessage = "employee phone is manditory")]
        public string Phone { get; set; }
    }
}
