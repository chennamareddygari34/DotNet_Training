using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Models.DTOs;
using BloggingPlatformApplication.Utilities;
using System.Security.Authentication;



namespace BloggingPlatformApplication.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int, Author> _repository;



        public LoginService(IRepository<int, Author> repository)
        {
            _repository = repository;
        }
        public bool Login(LoginDTO loginDTO)
        {
            //  throw new NotImplementedException();
            var myUser = _repository.GetAll().SingleOrDefault(u => u.AuthorId == loginDTO.Id && u.Phone == loginDTO.Password);
            if (myUser == null)
                return false;

            return true;



        }
    }
}