using HotelManagementApi.Models.DTOs;
using HotelManagementApi.Models;

namespace HotelManagementApi.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetAllRooms();

        public Room AddNewRoom(Room room);
        public Room UpdateRoomPrice(RoomDTO room);

        public Room DeleteRoom(int Id);
    }
}
