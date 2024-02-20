using Microsoft.AspNetCore.Identity;
using SocialMediaSite.Models;

namespace SocialMediaSite.Interfaces {
	public interface IDataAccessLayer {
		void addProfile(Profile profile);

		IdentityUser getUserFromID(string ID);

		bool doesUserExist(string UserName);
	}
}
