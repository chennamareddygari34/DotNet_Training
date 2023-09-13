using Microsoft.EntityFrameworkCore;
using SupplierAndProductManagementApp.Models;





namespace SupplierAndProductManagementApp.Interfaces
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Supplier> suppliers { get; set; }

        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Ramu", Email = "Ramu@gmail.com", Phone = "9087456321" },
                new Supplier { Id = 2, Name = "Balu", Email = "Balu@gmail.com", Phone = "97865412345" }
                );





        //    modelBuilder.Entity<Product>().HasData(
        //   new Product { Id = 1, Name = "abc product ", Description = "abc product is very nice ", Price = 98989, SupplierId = 1 },
        //   new Product { Id = 2, Name = "def product", Description = "def product is very nice ", Price = 78965, SupplierId = 2 }
        //   );
        //
        }





    }
}