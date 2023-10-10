using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;

namespace HotelManagementApi.Interfaces
{
    public interface IBookingService
    {
        List<Booking> GetAllBookings();
        bool BookARoom(int roomId, DateTime checkInDate, DateTime checkOutDate);
        Booking UpdateCheckIn(CheckInDTO checkInDTO);
        Booking UpdateCheckOut(CheckOutDTO checkOutDTO);
        bool CancelBooking(int Id);
        //List<Booking> GetOverlappingBookings(int roomId, DateTime checkInDate, DateTime checkOutDate);
    }
}
