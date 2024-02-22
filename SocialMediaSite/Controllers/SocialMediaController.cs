using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;
using System.Security.Claims;

namespace SocialMediaSite.Controllers {
	public class SocialMediaController : Controller {
		IDataAccessLayer dal;

		public SocialMediaController(IDataAccessLayer dal) {
			this.dal = dal;
		}

		public IActionResult AboutCreator() {
			return View();
		}

		[Authorize]
		[HttpGet]
		public IActionResult UserProfile(string profileUsername) {
			if(dal.doesUserExist(profileUsername)) {
				Profile profile = dal.getProfileFromUserName(profileUsername);

				IEnumerable<Post> postsForProfile = dal.getPostsForProfile(profile.ID);

				IEnumerable<string> posterNames = new List<string>();

				foreach(Post post in postsForProfile) {
					((List<string>) posterNames).Add(dal.getUserFromProfileID(post.PosterID).UserName);
				}

				return View("UserProfile", (profile, profileUsername, profile == dal.getProfileFromUser(GetCurrentUserID()), postsForProfile, posterNames));
			} else {
				return View("UserDoesntExist");
			}
		}

		[Authorize]
		[HttpPost]
		public IActionResult UserProfile(int postedOnID, string userName, string message) {
			Post post = new Post();
			post.Contents = message;
			post.PosterID = dal.getProfileFromUser(GetCurrentUserID()).ID;
			post.PostedOnID = postedOnID;

			dal.addPost(post);

			return Redirect("~/Profile/" + userName);
		}

		[Authorize]
		[HttpPost]
		public IActionResult ViewImages(int profileID) {
			string userName = dal.getUserFromProfileID(profileID).UserName;

			return View("ViewImages", (dal.getImagesFromProfileID(profileID), userName, dal.getUserFromProfileID(profileID) == dal.getUserFromID(GetCurrentUserID()), profileID));
		}

		[Authorize]
		[HttpPost]
		public IActionResult AddImage(int profileID, string imageURL) {
			Image image = new Image();
			image.URL = imageURL;
			image.ProfileID = profileID;
			dal.addImage(image);

			string userName = dal.getUserFromProfileID(profileID).UserName;

			return View("ViewImages", (dal.getImagesFromProfileID(profileID), userName, dal.getUserFromProfileID(profileID) == dal.getUserFromID(GetCurrentUserID()), profileID));
		}

		[HttpGet]
		public IActionResult SetupProfile() {
			return View();
		}

		[HttpPost]
		public IActionResult SetupProfile(Profile profile) {
			if(isProfileValid(profile)) {
				profile.UserID = GetCurrentUserID();

				dal.addProfile(profile);

				return Redirect("~/Profile/" + dal.getUserFromID(GetCurrentUserID()).UserName);
			} else {
				return View(profile);
			}
		}

		[Authorize]
		[HttpGet]
		public IActionResult EditProfile(int profileID) {
			return View("EditProfile", dal.getProfileFromID(profileID));
		}

		[Authorize]
		[HttpPost]
		public IActionResult EditProfile(Profile profile) {
			if(isProfileValid(profile)) {
				dal.updateProfile(profile);

				return Redirect("~/Profile/" + dal.getUserFromID(GetCurrentUserID()).UserName);
			} else {
				return View(profile);
			}
		}

		private bool isProfileValid(Profile profile) {
			ModelState.Clear();

			// Yes, it would be best to do the verification using the attribute tags, but I can't due to the virtual User required
			// to make the foreign key. I could get rid of the official foreign key and just treat it like one anyway, but I don't
			// want to do it like that, so now I get to have this function.
			if(profile.Name == null || profile.Name.Length > 250) {
				ModelState.AddModelError("Name", "Name cannot be blank");
			}
			if(profile.ProfilePicture == null) {
				ModelState.AddModelError("ProfilePicture", "The profile picture link cannot be blank");
			}
			if(profile.FavAnime == null || profile.FavAnime.Length > 100) {
				ModelState.AddModelError("FavAnime", "User must specify what their favorite anime is");
			}
			if(profile.FavAnimeEpisode == null || profile.FavAnimeEpisode.Length > 50) {
				ModelState.AddModelError("FavAnimeEpisode", "User must specify what their favorite anime episode is");
			}
			if(profile.LeastFavAnime == null || profile.LeastFavAnime.Length > 100) {
				ModelState.AddModelError("LeastFavAnime", "User must specify what their least favorite anime is");
			}

			return ModelState.IsValid;
		}

		private string GetCurrentUserID() {
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
