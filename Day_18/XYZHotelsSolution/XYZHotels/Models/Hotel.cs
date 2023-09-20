namespace XYZHotels.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string? Facility { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
