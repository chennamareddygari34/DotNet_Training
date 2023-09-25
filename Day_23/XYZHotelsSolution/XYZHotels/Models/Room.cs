using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZHotels.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string BedType { get; set; }
        public string Balcony { get; set; }
        public int Price { get; set; }
    }
}
