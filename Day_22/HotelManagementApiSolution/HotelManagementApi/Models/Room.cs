using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementApi.Models
{
    public class Room
    {
       // [Key]
        //public int Id { get; set; }
        [Key]
        public string RoomNo { get; set; }
        public decimal Price { get; set; }

        public int? HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
    }
}
