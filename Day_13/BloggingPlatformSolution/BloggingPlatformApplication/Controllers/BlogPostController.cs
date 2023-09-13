using BloggingPlatformApplication.Contexts;
using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Models.DTOs;
using BloggingPlatformApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformApplication.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        private readonly ILogger<BlogPostController> _logger;
        private readonly BlogContext _context;
        private BlogPost? blogPost;

        public BlogPostController(IBlogPostService blogPostService, ILogger<BlogPostController> logger, BlogContext context)
        {
            _blogPostService = blogPostService;
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            List<BlogPost> blogPosts = new List<BlogPost>();
            try
            {
                blogPosts = _blogPostService.GetAllBlogs().ToList();
                return View(blogPosts);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogInformation("There were no blog posts");
            }
            return View(blogPosts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            try
            {
                var blog = _blogPostService.Add(blogPost);
                _logger.LogInformation("Created blog post record..");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to add blog post.. ");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var blog = _blogPostService.GetAllBlogs().SingleOrDefault(x => x.AuthorId == id);
            var blogPost = new BlogPostDTO { Id = id, Title = blog.Title, Content = blog.Content };
            return View(blogPost);
        }
        [HttpPost]
        public IActionResult Update(int id, BlogPostDTO blogPost)
        {
            try
            {
                var result = _blogPostService.UpdateTitleAndContent(blogPost);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to upadte author phone... ");
            }
            return View(blogPost);
        }
         [HttpGet]
        public IActionResult Delete(int id)
        {
            BlogPost blogPost = _blogPostService.GetAllBlogs().FirstOrDefault(x => x.Id == id);
            return View(blogPost);
        }
        [HttpPost]
        public IActionResult Delete(int id, BlogPost blogPost)
        {
            blogPost = _blogPostService.GetAllBlogs().FirstOrDefault(x => x.Id == id);
            _context.blogPosts.Remove(blogPost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
