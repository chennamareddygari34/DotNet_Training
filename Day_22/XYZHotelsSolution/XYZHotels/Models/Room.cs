using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZHotels.Models
{
    public class Room
    {
        [Key]
        public string RoomId { get; set; }
        public string BedType { get; set; }
        public bool Balcony { get; set; }
        public float Price { get; set; }
        public int? HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
    }
}
