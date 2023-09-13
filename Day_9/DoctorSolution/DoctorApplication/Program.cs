using DoctorApplication.Contexts;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using DoctorApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoctorApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            #region InjectUSerdefinedServices
            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();
            //builder.Services.AddScoped<IPizzaService, PizzaServicecs>();
            //builder.Services.AddScoped<IManagePizzaService, PizzaServicecs>();
            #endregion

            #region AddingConetexts
            builder.Services.AddDbContext<DoctorContext>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            var app = builder.Build();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}