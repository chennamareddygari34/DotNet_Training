using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;

namespace HotelManagementApi.Services
{
    public class RoomService:IRoomService
    {

        private readonly IRepository<string, Room> _repository;



        public RoomService(IRepository<string, Room> repository)
        {
            _repository = repository;
        }
        public Room AddNewRoom(Room room)
        {
            return _repository.Add(room);
        }



        public Room DeleteRoom(string Id)
        {
            return _repository.Delete(Id);
        }

        public Room DeleteRoom(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            return _repository.GetAll().ToList();
        }



      
        public Room UpdateRoomPrice(RoomDTO room)
        {
            var myRoom = _repository.Get(room.RoomNo);
            if (myRoom != null)
            {
                myRoom.Price = room.Price;
                return _repository.Update(myRoom);
            }
            return null;
        }
    }
}

