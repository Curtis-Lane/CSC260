using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace MoviesDAL_DI.Data {
	public class AppDbContext : DbContext {
		public DbSet<Movie> Movies {get; set;}

		public AppDbContext(DbContextOptions options) : base(options) {
			//
		}
	}
}