using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Models.DTOs;

namespace BloggingPlatformApplication.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IRepository<int, BlogPost> _repository;

        public BlogPostService(IRepository<int, BlogPost> repository)
        {
            _repository = repository;
        }
        public BlogPost Add(BlogPost entity)
        {
            var blogPost = _repository.Add(entity);
            return blogPost;
        }

        public IList<BlogPost> GetAllBlogs()
        {
            return _repository.GetAll().ToList();
        }

        public BlogPost UpdateTitleAndContent(BlogPostDTO blogpost)
        {
            var myBlog = _repository.GetById(blogpost.Id);
            myBlog.Title = blogpost.Title;
            myBlog.Content = blogpost.Content;
            _repository.Update(myBlog);
            return myBlog;
        }
    }
}
