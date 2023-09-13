using BloggingPlatformApplication.Contexts;
using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;
        private readonly BlogContext _context;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger, BlogContext context)
        {
            _authorService = authorService;
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Author> authors = new List<Author>();
            try
            {
                authors = _authorService.GetAllAuthors().ToList();
                return View(authors);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogInformation("There were no authors");
            }
            return View(authors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            try
            {
                var myAuthor = _authorService.Add(author);
                _logger.LogInformation("Created author record");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to add author ");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdatePhone(int id)
        {
            var auth = _authorService.GetAllAuthors().SingleOrDefault(x => x.AuthorId == id);
            var author = new AuthorDTO { AuthorId = id, Phone = auth.Phone };
            return View(author);
        }
        [HttpPost]
        public IActionResult UpdatePhone(int id, AuthorDTO author)
        {
            try
            {
                var result = _authorService.UpdatePhone(author);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to upadte author phone... ");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult UpdateEmail(int id)
        {
            var auth = _authorService.GetAllAuthors().SingleOrDefault(x => x.AuthorId == id);
            var author = new AuthorDTO { AuthorId = id, Email = auth.Email };
            return View(author);
        }
        [HttpPost]
        public IActionResult UpdateEmail(int id, AuthorDTO author)
        {
            try
            {
                var result = _authorService.UpdateEmail(author);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to update author email... ");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Author author = _authorService.GetAllAuthors().FirstOrDefault(x => x.AuthorId == id);
            return View(author);
        }
        [HttpPost]
        public IActionResult Delete(int id, Author author)
        {
            author = _authorService.GetAllAuthors().FirstOrDefault(x => x.AuthorId == id);
            _context.authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UserLogout(string un)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("UserLogin", "Login");
        }
    }
}
