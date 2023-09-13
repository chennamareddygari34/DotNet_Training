using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Models.DTOs;

namespace BloggingPlatformApplication.Interfaces
{
    public interface ILoginService
    {
        public bool Login(LoginDTO loginDTO);
    }
}
