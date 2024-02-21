﻿using Microsoft.AspNetCore.Identity;
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

		public Profile getProfileFromUser(string ID) {
			return db.Profiles.Where(p => p.UserID == ID).FirstOrDefault();
		}

		public Profile getProfileFromID(int ID) {
			return db.Profiles.Where(p => p.ID == ID).FirstOrDefault();
		}

		public Profile getProfileFromUserName(string UserName) {
			return db.Profiles.Where(p => p.UserID == getUserFromUserName(UserName).Id).FirstOrDefault();
		}

		public IdentityUser getUserFromUserName(string UserName) {
			return db.Users.Where(u => u.UserName == UserName).FirstOrDefault();
		}

		public IdentityUser getUserFromID(string ID) {
			return db.Users.Where(u => u.Id == ID).FirstOrDefault();
		}

		public IdentityUser getUserFromProfileID(int ID) {
			Profile prof = getProfileFromID(ID);

			return db.Users.Where(u => u.Id == prof.UserID).FirstOrDefault();
		}

		public IEnumerable<Image> getImagesFromProfileID(int ID) {
			return db.Images.Where(i => i.ProfileID == ID);
		}

		public bool doesUserExist(string UserName) {
			return (db.Users.Where(x => x.UserName == UserName).FirstOrDefault()) != null;
		}
	}
}
