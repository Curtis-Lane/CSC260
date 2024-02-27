using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMediaSite.Data;
using SocialMediaSite.Interfaces;

namespace SocialMediaSite {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
			//	.AddEntityFrameworkStores<ApplicationDbContext>();

			builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddDefaultUI().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();

			builder.Services.AddRazorPages();

			builder.Services.AddTransient<IDataAccessLayer, SocialMediaDAL>();

			builder.Services.Configure<IdentityOptions>(options => {
				// Password settings
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 10;
				options.Password.RequiredUniqueChars = 1; // Number of non-alphanumeric characters required
				// Why doesn't this last one work?
				
				// Lockout
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = false;

				// User
				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedAccount = false;
				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedPhoneNumber = false;
			});

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if(app.Environment.IsDevelopment()) {
				app.UseMigrationsEndPoint();
			} else {
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Landing}/{id?}"
			);

			app.MapControllerRoute(
				name: "UserProfile",
				pattern: "/Profile/{profileUsername}",
				defaults: new {controller = "SocialMedia", action = "UserProfile"}
			);

			app.MapControllerRoute(
				name: "UserProfile",
				pattern: "/{profileUsername}",
				defaults: new {controller = "SocialMedia", action = "UserProfile"}
			);
			
			app.MapControllerRoute(
				name: "TheFinalCatchAll",
				pattern: "{*any}",
				defaults: new {controller="Home", action="Index"}
			);

			app.MapRazorPages();

			app.Run();
		}
	}
}