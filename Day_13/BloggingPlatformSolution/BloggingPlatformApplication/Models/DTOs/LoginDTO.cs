using System.ComponentModel.DataAnnotations;

namespace BloggingPlatformApplication.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User Id is manditory")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Password is manditory")]
        public string Password { get; set; }

    }
}
