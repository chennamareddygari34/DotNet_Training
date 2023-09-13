using System.ComponentModel.DataAnnotations;

namespace BloggingPlatformApplication.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "please enter author name..")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please enter mobile no..")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "please enter email id..")]
        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string Pic { get; set; }

        //public ICollection<BlogPost> Posts { get; set; }
    }
}
