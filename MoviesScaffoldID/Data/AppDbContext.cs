using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MoviesScaffoldID.Models;

namespace MoviesScaffoldID.Data {
	public class AppDbContext : IdentityDbContext {
		// Will create Movies table in the DB using Movie.cs model
		public DbSet<Movie> Movies {get; set;}

		public AppDbContext(DbContextOptions options) : base(options) {
			//
		}
	}
}