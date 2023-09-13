using System.Numerics;
using BloggingPlatformApplication.Contexts;
using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformApplication.Repositories
{
    public class AuthorRepository : IRepository<int, Author>
    {
        private readonly BlogContext _context;

        public AuthorRepository(BlogContext context)
        {
            _context = context;
        }
        public Author Add(Author entity)
        {
            _context.authors.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Author Delete(int key)
        {
            var author = GetById(key);
            if (author != null)
            {
                _context.authors.Remove(author);
                _context.SaveChanges();
                return author;
            }
            throw new NoSuchAuthorsException();
        }

        public ICollection<Author> GetAll()
        {
            var authors = _context.authors;
            if (authors.Count() == 0)
                throw new NoAuthorsAvailableException();
            return authors.ToList();
        }

        public Author GetById(int key)
        {
            var author = _context.authors.SingleOrDefault(d => d.AuthorId == key);
            if (author != null)
                return author;
            throw new NoSuchAuthorsException();
        }

        public Author Update(Author entity)
        {
            var author = GetById(entity.AuthorId);
            if (author != null)
            {
                _context.Entry<Author>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new NoSuchAuthorsException();
        }
    }
}
