using System.ComponentModel.DataAnnotations;

namespace HotelManagementApi.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}
