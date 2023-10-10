using HotelManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApi.Contexts
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<User> users { get; set; }
    }
    
}
