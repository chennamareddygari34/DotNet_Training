using XYZHotels.Models;
using XYZHotels.Models.DTOs;

namespace XYZHotels.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetAllRooms();
        Room AddANewRoom(Room room);
        Room UpdatePrice(RoomDTO room);
        Room DeleteRoom(int Id);
    }
}
