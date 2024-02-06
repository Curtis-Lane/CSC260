using MoviesDAL.Interfaces;
using MoviesDAL.Data;
using MoviesDAL_DI.Data;
using Microsoft.EntityFrameworkCore;

namespace Movies {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			//
			builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Send in DAL as dependency
			// Transient = Creates new object each time service is requested
			// Scoped = Instances are created once per request, on refresh you get new instance
			// Singleton = Always return the same object instance
			builder.Services.AddTransient<IDataAccessLayer, LeastFavoriteMoviesDAL>();

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
				pattern: "{controller=Home}/{action=Index}/{id?}"
			);

			app.Run();
		}
	}
}