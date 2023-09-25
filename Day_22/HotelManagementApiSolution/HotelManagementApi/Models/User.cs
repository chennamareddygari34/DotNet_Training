using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HotelManagementApi.Models
{
    public class User
    {

        [Key]
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[]? Key { get; set; }

        public string? Role { get; set; }


    }
}
