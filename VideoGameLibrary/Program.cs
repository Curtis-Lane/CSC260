using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VideoGameLibrary {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			// Send in DB Context as dependency
			builder.Services.AddDbContext<VideoGameDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Send in DAL as dependency
			builder.Services.AddTransient<IDataAccessLayer, VideoGameDBDal>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment()) {
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