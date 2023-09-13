using System.Numerics;
using EmployeeLoginApplication.Context;
using EmployeeLoginApplication.Interfaces;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Repositories;
using EmployeeLoginApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoginApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<ILoginService, LoginService>();

            builder.Services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=UserLogin}/{id?}");

            app.Run();
        }
    }
}