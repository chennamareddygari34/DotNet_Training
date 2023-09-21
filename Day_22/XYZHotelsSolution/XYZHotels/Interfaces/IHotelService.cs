using XYZHotels.Models;
using XYZHotels.Models.DTOs;

namespace XYZHotels.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();
        Hotel AddANewHotel(Hotel hotel);
        Hotel UpdateFacility(HotelDTO hotel);
        Hotel DeletetHotel(int Id);
    }
}
