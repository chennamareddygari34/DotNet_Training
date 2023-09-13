using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Models.DTOs;

namespace BloggingPlatformApplication.Interfaces
{
    public interface IAuthorService : IAddingEntity<Author>
    {
        public Author UpdatePhone(AuthorDTO author);
        public Author UpdateEmail(AuthorDTO author);
        public IList<Author> GetAllAuthors();
    }
}
