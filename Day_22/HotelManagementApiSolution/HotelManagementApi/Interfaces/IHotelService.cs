using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;

namespace HotelManagementApi.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();

        Hotel AddANewHotel(Hotel hotel);
        Hotel UpdateHotelName(HotelDTO hotel);
        public Hotel DeleteHotel(int Id);
    }
}
