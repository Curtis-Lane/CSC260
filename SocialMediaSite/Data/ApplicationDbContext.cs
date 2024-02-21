using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data {
	public class ApplicationDbContext : IdentityDbContext {
		public DbSet<Profile> Profiles {get; set;}
		//public DbSet<Post> Posts {get; set;}
		public DbSet<Image> Images {get; set;}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
			//
		}
	}
}
