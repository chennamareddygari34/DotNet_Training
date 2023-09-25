using HotelManagementApi.Contexts;
using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;

namespace HotelManagementApi.Repositories
{
    public class HotelRepository : IRepository<int, Hotel>

    {
        
        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context = context;
        }
        public Hotel Add(Hotel item)
        {
            //throw new NotImplementedException();
            _context.hotels.Add(item);
            _context.SaveChanges();
            return item;

        }

        public Hotel Delete(int key)
        {
            //throw new NotImplementedException();
            var hotel = Get(key);
            if (hotel != null)
            {
                _context.hotels.Remove(hotel);
                _context.SaveChanges();
                return hotel;
            }
            return null;
        }

        public Hotel Get(int key)
        {
            //throw new NotImplementedException();
            var hotel = _context.hotels.FirstOrDefault(p => p.Id == key);
            return hotel;
        }

        public List<Hotel> GetAll()
        {
          //  throw new NotImplementedException();
          return _context.hotels.ToList();
        }

        public Hotel Update(Hotel item)
        {
            // throw new NotImplementedException();
            _context.Entry<Hotel>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;

        }
    }
}
