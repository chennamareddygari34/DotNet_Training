using System.Numerics;
using BloggingPlatformApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformApplication.Contexts
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> blogPosts { get; set; }
        public DbSet<Author> authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                 new Author { AuthorId = 1, Name = "Pavan", Phone = "8121288262", Email = "Pavan@123", Pic = "/images/image1.jpg " },
                 new Author { AuthorId = 2, Name = "Babu", Phone = "9989355384", Email = "Babu@123", Pic = "/images/image2.jpg " }
                 );

        }
    }
}
