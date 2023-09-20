﻿using XYZHotels.Contexts;
using XYZHotels.Interfaces;
using XYZHotels.Models;

namespace XYZHotels.Repositories
{
    public class RoomRepository : IRepository<string, Room>
    {
        private readonly XYZHotelContext _context;
        public RoomRepository(XYZHotelContext context)
        {
            _context = context;
        }
        public Room Add(Room item)
        {
            _context.rooms.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Room Delete(string key)
        {
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
            var room = _context.rooms.FirstOrDefault(x => x.RoomId == key);
            return room;
        }

        public List<Room> GetAll()
        {
            return _context.rooms.ToList();
        }

        public Room Update(Room item)
        {
            _context.Entry<Room>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
