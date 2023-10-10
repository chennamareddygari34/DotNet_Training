using Microsoft.EntityFrameworkCore;
using HotelManagementApi.Contexts;
using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;

namespace HotelManagementApi.Repositories
{
    public class BookingRepository : IRepository<int, Booking>
    {
        private readonly HotelContext _context;

        public BookingRepository(HotelContext context)
        {
            _context = context;
        }
        public Booking Add(Booking item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.bookings.Add(item);
            _context.SaveChanges();
            return item;
        }
    

        public Booking Delete(int key)
        {
            var booking = Get(key);
            if (booking != null)
            {
                _context.bookings.Remove(booking);
                _context.SaveChanges();
                return booking;
            }
            return null;
        }

        public Booking Get(int key)
        {
            var booking = _context.bookings.FirstOrDefault(x => x.Id == key);
            return booking;
        }

        public List<Booking> GetAll()
        {
            return _context.bookings.ToList();
        }

        public Booking Update(Booking item)
        {
            _context.Entry<Booking>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        //public List<Booking> GetOverlappingBookings(int roomId, DateTime checkInDate, DateTime checkOutDate)
        //{
        //    return _context.bookings
        //        .Where(b => b.RoomId == roomId &&
        //                    b.CheckInDate < checkOutDate &&
        //                    b.CheckOutDate > checkInDate)
        //        .ToList();
        //}
    }
}
