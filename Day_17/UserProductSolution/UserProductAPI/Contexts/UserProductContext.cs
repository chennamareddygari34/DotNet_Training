using Microsoft.EntityFrameworkCore;
using UserProductAPI.Models;



namespace UserProductAPI.Contexts
{
    public class UserProductContext : DbContext
    {
        public UserProductContext(DbContextOptions opts) : base(opts)
        {



        }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Supplier>().HasKey(es => new { es.Id, es.Email });



            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Ramu", Price = 25.00f, Quantity = 5 },
                new Product { Id = 2, Name = "Somu", Price = 48.25f, Quantity = 3 }



                );





        }
    }
}