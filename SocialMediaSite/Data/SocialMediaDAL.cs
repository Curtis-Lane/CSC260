using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data {
	public class SocialMediaDAL : IDataAccessLayer {
		private ApplicationDbContext db;

		public SocialMediaDAL(ApplicationDbContext db) {
			this.db = db;
		}
	}
}
