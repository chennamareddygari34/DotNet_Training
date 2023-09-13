using System.Numerics;
using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Models.DTOs;

namespace BloggingPlatformApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<int, Author> _repository;

        public AuthorService(IRepository<int, Author> repository)
        {
            _repository = repository;
        }
        public Author Add(Author entity)
        {
            var author = _repository.Add(entity);
            return author;
        }

        public IList<Author> GetAllAuthors()
        {
            return _repository.GetAll().ToList();
        }

        public Author UpdateEmail(AuthorDTO author)
        {
            var myAuthor = _repository.GetById(author.AuthorId);
            myAuthor.Email = author.Email;
            _repository.Update(myAuthor);
            return myAuthor;
        }

        public Author UpdatePhone(AuthorDTO author)
        {
            var myAuthor = _repository.GetById(author.AuthorId);
            myAuthor.Phone = author.Phone;
            _repository.Update(myAuthor);
            return myAuthor;
        }
    }
}
