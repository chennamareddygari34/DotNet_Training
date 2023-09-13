using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models.DTOs;
using BloggingPlatformApplication.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        //Route("Login")]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        //[Route("Login")]
        public IActionResult UserLogin(LoginDTO loginDTO)
        {
            var result = _loginService.Login(loginDTO);
            if (result)
            {
                HttpContext.Session.SetInt32("UserId", loginDTO.Id);
                return RedirectToAction("Index", "Blogpost");
            }



            ViewBag.ErrorMessage = "Invalid username or password";
            return View(loginDTO);
        }
    }
}
