using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data {
	public class ApplicationDbContext : IdentityDbContext {
		public DbSet<Profile> Profiles {get; set;}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
			//
		}
	}
}
