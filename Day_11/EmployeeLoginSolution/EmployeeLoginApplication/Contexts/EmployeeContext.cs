using EmployeeLoginApplication.Models;
using Microsoft.EntityFrameworkCore;



namespace EmployeeLoginApplication.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {



        }
        public DbSet<Employee> employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Pavan", DeptName = "Mathematics", Email = "Pavan@gmail.com", Phone = "+919989355384", Pic = "/images/emp1.jpg" },
                 new Employee { Id = 2, Name = "Babu", DeptName = "Physics", Email = "Babu@gmail.com", Phone = "+91812128826", Pic = "/images/emp2.jpg" }
                );
        }
    }
}