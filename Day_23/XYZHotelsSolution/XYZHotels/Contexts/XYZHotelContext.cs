using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using XYZHotels.Models;

namespace XYZHotels.Contexts
{
    public class XYZHotelContext : DbContext
    {
        public XYZHotelContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Supplier>().HasKey(es => new { es.Id, es.Email });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, HotelName = "ABC", Facility = "Road-Side" },
                new Hotel { Id = 2, HotelName = "DEF", Facility = "Bustand-Road" }
                );
            modelBuilder.Entity<Room>().HasData(
               new Room { RoomId = 1, BedType = "Single", Balcony = "true", Price = 6500 },
               new Room { RoomId = 2, BedType = "Double", Balcony = "false", Price = 9000 }
               );

        }
    }
}
