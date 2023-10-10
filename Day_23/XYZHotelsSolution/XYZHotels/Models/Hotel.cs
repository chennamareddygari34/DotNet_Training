using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZHotels.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string? Facility { get; set; }
        public bool? IsActive { get; set; }
        public string? Pic { get; set; }
    }
}
