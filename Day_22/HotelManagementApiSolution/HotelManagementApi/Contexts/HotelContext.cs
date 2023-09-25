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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "RajaHamsa", Location="Banglore"},
                new Hotel { Id = 2, Name = "Taj", Location = "Agra" }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomNo = "1", Price = 2000,HotelId = 1 },
                new Room { RoomNo = "2", Price = 1500, HotelId = 2 }
                );

        }
    }
}
