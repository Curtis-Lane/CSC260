using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace MoviesDAL_DI.Data {
	public class AppDbContext : DbContext {
		// Will create Movies table in the DB using Movie.cs model
		public DbSet<Movie> Movies {get; set;}

		public AppDbContext(DbContextOptions options) : base(options) {
			//
		}
	}
}