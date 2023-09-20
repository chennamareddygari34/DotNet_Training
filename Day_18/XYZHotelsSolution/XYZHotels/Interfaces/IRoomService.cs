using XYZHotels.Models;

namespace XYZHotels.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetAllRooms();
        Room AddANewRoom(Room room);
        Room UpdatePrice(Room room);
        Room DeleteRoom(string Id);
    }
}
