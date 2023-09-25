using HotelManagementApi.Contexts;
using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;

namespace HotelManagementApi.Repositories
{
    public class RoomRepository : IRepository<string, Room>
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context=context;
            
        }
        public Room Add(Room item)
        {
            //throw new NotImplementedException();
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Room Delete(string key)
        {
            //throw new NotImplementedException();
            var room = Get(key);
            if (room != null)
            {
                _context.rooms.Remove(room);
                _context.SaveChanges();
                return room;
            }
            return null;
        }

        public Room Get(string key)
        {
            //throw new NotImplementedException();
            var room = _context.rooms.FirstOrDefault(us => us.RoomNo == key);
            return room;
        }

        public List<Room> GetAll()
        {
            //throw new NotImplementedException();
            return _context.rooms.ToList();
        }

        public Room Update(Room item)
        {
            //throw new NotImplementedException();
            _context.Entry<Room>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
