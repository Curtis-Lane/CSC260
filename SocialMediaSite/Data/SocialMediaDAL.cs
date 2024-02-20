using Microsoft.AspNetCore.Identity;
using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data {
	public class SocialMediaDAL : IDataAccessLayer {
		private ApplicationDbContext db;

		public SocialMediaDAL(ApplicationDbContext db) {
			this.db = db;
		}

		public void addProfile(Profile profile) {
			db.Profiles.Add(profile);
			db.SaveChanges();
		}

		public IdentityUser getUserFromID(string ID) {
			return db.Users.Where(u => u.Id == ID).FirstOrDefault();
		}

		public bool doesUserExist(string UserName) {
			return (db.Users.Where(x => x.UserName == UserName).FirstOrDefault()) != null;
		}
	}
}
