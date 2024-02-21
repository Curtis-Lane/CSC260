using Microsoft.AspNetCore.Identity;
using SocialMediaSite.Models;

namespace SocialMediaSite.Interfaces {
	public interface IDataAccessLayer {
		void addProfile(Profile profile);

		void updateProfile(Profile profile);

		void addPost(Post post);

		IEnumerable<Post> getPostsForProfile(int profileID);

		Profile getProfileFromUser(string ID);

		Profile getProfileFromID(int ID);

		Profile getProfileFromUserName(string UserName);

		IdentityUser getUserFromUserName(string UserName);

		IdentityUser getUserFromID(string ID);

		IdentityUser getUserFromProfileID(int ID);

		void addImage(Image image);

		IEnumerable<Image> getImagesFromProfileID(int ID);

		bool doesUserExist(string UserName);
	}
}
