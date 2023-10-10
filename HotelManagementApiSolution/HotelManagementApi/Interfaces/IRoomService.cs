using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;

namespace HotelManagementApi.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetAllRooms();
        bool AddANewRoom(Room room);
        Room UpdatePrice(RoomDTO room);
        Room DeleteRoom(int Id);
    }
}
