using UserProductAPI.Models;
using UserProductAPI.Models.DTOs;



namespace UserProductAPI.Interfaces
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}