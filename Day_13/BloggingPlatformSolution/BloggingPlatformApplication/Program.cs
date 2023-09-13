using BloggingPlatformApplication.Contexts;
using BloggingPlatformApplication.Interfaces;
using BloggingPlatformApplication.Models;
using BloggingPlatformApplication.Repositories;
using BloggingPlatformApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BlogContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IRepository<int, Author>, AuthorRepository>();
            builder.Services.AddScoped<IRepository<int, BlogPost>, Repositories.BlogPostRepository>();
            builder.Services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(5);
            });
            builder.Services.AddMemoryCache();

            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBlogPostService, BlogPostService>();
            builder.Services.AddScoped<ILoginService, LoginService>();


            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=UserLogin}/{id?}");

            app.Run();
        }
    }
}