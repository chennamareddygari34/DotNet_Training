using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public bool IsBooked { get; set; }
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }

    }
}
