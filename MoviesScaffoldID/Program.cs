using MoviesScaffoldID.Interfaces;
using MoviesScaffoldID.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MoviesScaffoldID {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Send in DB Context as dependency
			//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
			//	.AddEntityFrameworkStores<AppDbContext>();

			builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddDefaultUI()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<AppDbContext>();

			// Send in DAL as dependency
			// Transient = Creates new object each time service is requested
			// Scoped = Instances are created once per request, on refresh you get new instance
			// Singleton = Always return the same object instance
			builder.Services.AddTransient<IDataAccessLayer, LeastFavoriteMoviesDAL>();

			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if(!app.Environment.IsDevelopment()) {
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();
			
			app.UseAuthentication();

			app.UseAuthorization();

			app.MapRazorPages();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"
			);

			app.Run();
		}
	}
}