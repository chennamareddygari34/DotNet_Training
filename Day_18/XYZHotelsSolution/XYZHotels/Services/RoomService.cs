using XYZHotels.Interfaces;
using XYZHotels.Models;

namespace XYZHotels.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<string, Room> _repository;

        public RoomService(IRepository<string, Room> repository)
        {
            _repository = repository;
        }
        public Room AddANewRoom(Room room)
        {
            return _repository.Add(room);
        }

        public Room DeleteRoom(string Id)
        {
            return _repository.Delete(Id);
        }

        public List<Room> GetAllRooms()
        {
            return _repository.GetAll().ToList();
        }

        public Room UpdatePrice(Room room)
        {
            var myRoom = _repository.Get(room.RoomId);
            if (myRoom != null)
            {
                myRoom.Price = room.Price;
                return _repository.Update(myRoom);
            }
            return null;
        }
    }
}
