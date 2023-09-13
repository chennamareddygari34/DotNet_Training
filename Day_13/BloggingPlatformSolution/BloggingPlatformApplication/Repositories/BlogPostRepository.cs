using BloggingPlatformApplication.Contexts;
using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformApplication.Repositories
{
    public class BlogPostRepository : IRepository<int, BlogPost>
    {
        private readonly BlogContext _context;

        public BlogPostRepository(BlogContext context)
        {
            _context = context;
        }
        public BlogPost Add(BlogPost entity)
        {
            _context.blogPosts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public BlogPost Delete(int key)
        {
            var blogPost = GetById(key);
            if (blogPost != null)
            {
                _context.blogPosts.Remove(blogPost);
                _context.SaveChanges();
                return blogPost;
            }
            throw new NoSuchBlogPostException();
        }

        public ICollection<BlogPost> GetAll()
        {
            var blogPosts = _context.blogPosts;
            if (blogPosts.Count() == 0)
                throw new NoBlogPostsAvailableException();
            return blogPosts.ToList();
        }

        public BlogPost GetById(int key)
        {
            var blogPost = _context.blogPosts.SingleOrDefault(d => d.Id == key);
            if (blogPost != null)
                return blogPost;
            throw new NoSuchBlogPostException();
        }

        public BlogPost Update(BlogPost entity)
        {
            var blogPost = GetById(entity.Id);
            if (blogPost != null)
            {
                _context.Entry<BlogPost>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new NoSuchBlogPostException();
        }
    }
}
