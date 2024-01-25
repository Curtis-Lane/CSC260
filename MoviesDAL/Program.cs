namespace Movies {
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
				pattern: "{controller=Home}/{action=Index}/{id?}"
			);

			//app.MapControllerRoute(
			//	name: "PizzaRouteTest",
			//	//pattern: "pizza",
			//	//pattern: "pizza{id}",
			//	//pattern: "pizza/{id?}",
			//	pattern: "pizza/{id:int?}", // Only takes an integer
			//	defaults: new {controller="Home", action="RouteTest"}
			//);

			//app.MapControllerRoute(
			//	name: "LotsOfPrettyColors",
			//	pattern: "Home/Colors/{*colors}",
			//	defaults: new {controller="Home", action="Colors"}
			//);

			// Catches all errors and routes to the Error.cshtml view
			//app.MapControllerRoute(
			//	name: "TheFinalCatchAll",
			//	pattern: "{*any}",
			//	defaults: new {controller="Home", action="error"}
			//);

			app.Run();
		}
	}
}