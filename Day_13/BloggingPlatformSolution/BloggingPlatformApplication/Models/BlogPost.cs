using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformApplication.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter title..")]
        public string Title { get; set; }

        [Required(ErrorMessage = "please enter Description..")]
        [MinLength(10, ErrorMessage = "Please describe 10words atleast..")]
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "please enter authorId..")]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
