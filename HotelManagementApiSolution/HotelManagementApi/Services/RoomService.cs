using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;
using HotelManagementApi.Repositories;

namespace HotelManagementApi.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> _repository;

        public RoomService(IRepository<int, Room> repository)
        {
            _repository = repository;
        }
        public bool AddANewRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            Room existingRoom = _repository.Get(room.Id);

            if (existingRoom != null)
            {
                return false;
            }

            _repository.Add(room);

            return true;
        }

        public Room DeleteRoom(int Id)
        {
            return _repository.Delete(Id);
        }

        public List<Room> GetAllRooms()
        {
            return _repository.GetAll().ToList();
        }

        public Room UpdatePrice(RoomDTO room)
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
