using XYZHotels.Models;

namespace XYZHotels.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();
        Hotel AddANewHotel(Hotel hotel);
        Hotel UpdateFacility(Hotel hotel);
        Hotel DeletetHotel(int Id);
    }
}
