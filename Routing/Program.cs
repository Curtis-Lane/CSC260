namespace Routing {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

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
				pattern: "{controller=Home}/{action=Privacy}/{id?}"
			);

			app.MapControllerRoute(
				name: "Chicken",
				pattern: "/EatMoreChicken",
				defaults: new {controller="Home", action="Chicken"}
			);

			app.MapControllerRoute(
				name: "DefaultCow",
				pattern: "/{mooCount:int}",
				defaults: new {controller="Home", action="DefaultCow"}
			);

			app.MapControllerRoute(
				name: "NamedCow",
				pattern: "/{mooCount:int}/{cowName}",
				defaults: new {controller="Home", action="NamedCow"}
			);

			app.MapControllerRoute(
				name: "AllCowsCount",
				pattern: "/AllCows/Gallery/{cowCount:int}",
				defaults: new {controller="Home", action="AllCowsCount"}
			);

			app.MapControllerRoute(
				name: "AllCowsCountPerPage",
				pattern: "/AllCows/Gallery/{cowCount:int}/Page{pageNumber:int}",
				defaults: new {controller="Home", action="AllCowsCountPerPage"}
			);

			app.MapControllerRoute(
				name: "AllCowsCountOnPage",
				pattern: "/AllCows/Gallery/{cowCount:int}/{pageNumber:int}",
				defaults: new {controller="Home", action="AllCowsCountOnPage"}
			);

			app.MapControllerRoute(
				name: "TheFinalCatchAll",
				pattern: "{*any}",
				defaults: new {controller="Home", action="Index"}
			);

			app.Run();
		}
	}
}