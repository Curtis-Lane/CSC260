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

				return View("UserProfile", (profile, profile == dal.getProfileFromUser(GetCurrentUserID())));
			} else {
				return View("UserDoesntExist");
			}
		}

		[Authorize]
		[HttpPost]
		public IActionResult UserProfile() {
			return View("UserProfile"); // TODO: When I get posts figured out
		}

		[Authorize]
		[HttpPost]
		public IActionResult ViewImages(int profileID) {
			string userName = dal.getUserFromProfileID(profileID).UserName;

			return View("ViewImages", (dal.getImagesFromProfileID(profileID), userName));
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

				//return Redirect("~/Profile/" + dal.getUserFromID(GetCurrentUserID()).UserName);
				return RedirectToAction("UserProfile", dal.getUserFromID(GetCurrentUserID()).UserName);
			} else {
				return View();
			}
		}

		private bool isProfileValid(Profile profile) {
			if(profile.Name == null || profile.ProfilePicture == null || profile.FavAnime == null || profile.FavAnimeEpisode == null || profile.LeastFavAnime == null) {
				return false;
			} else {
				return true;
			}
		}

		private string GetCurrentUserID() {
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
