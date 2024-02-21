using Microsoft.AspNetCore.Identity;
using SocialMediaSite.Models;

namespace SocialMediaSite.Interfaces {
	public interface IDataAccessLayer {
		void addProfile(Profile profile);

		Profile getProfileFromUser(string ID);

		Profile getProfileFromID(int ID);

		Profile getProfileFromUserName(string UserName);

		IdentityUser getUserFromUserName(string UserName);

		IdentityUser getUserFromID(string ID);

		IdentityUser getUserFromProfileID(int ID);

		IEnumerable<Image> getImagesFromProfileID(int ID);

		bool doesUserExist(string UserName);
	}
}
