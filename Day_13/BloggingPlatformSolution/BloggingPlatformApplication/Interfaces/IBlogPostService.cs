using BloggingPlatformApplication.Models.DTOs;
using BloggingPlatformApplication.Models;

namespace BloggingPlatformApplication.Interfaces
{
    public interface IBlogPostService : IAddingEntity<BlogPost>
    {
        public BlogPost UpdateTitleAndContent(BlogPostDTO blogpost);
        public IList<BlogPost> GetAllBlogs();

    }
}
