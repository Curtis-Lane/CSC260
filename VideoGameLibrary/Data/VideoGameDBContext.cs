using Microsoft.EntityFrameworkCore;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Data {
	public class VideoGameDBContext : DbContext {
		public DbSet<VideoGame> VideoGames {get; set;}

		public VideoGameDBContext(DbContextOptions options) : base(options) {
			//
		}
	}
}
