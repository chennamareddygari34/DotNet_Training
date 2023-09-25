using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementApi.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
       
        public DateTime BookingDateTime { get; set; }
        public string? RoomNo { get; set; }
        [ForeignKey("RoomNo")]
        public Room? Room { get; set; }
    }
}
