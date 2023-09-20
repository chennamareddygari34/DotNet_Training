using System.ComponentModel.DataAnnotations;

namespace XYZHotels.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public int[] Password { get; set; }
        public int[]? Key { get; set; }
        public string? Role { get; set; }
    }
}
