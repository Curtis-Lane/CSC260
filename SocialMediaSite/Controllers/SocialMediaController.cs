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
		public IActionResult UserProfile(string profileUsername) {
			if(dal.doesUserExist(profileUsername)) {
				//

				return View("UserProfile");
			} else {
				return View("UserDoesntExist");
			}
		}

		[HttpGet]
		public IActionResult SetupProfile() {
			return View();
		}

		[HttpPost]
		public IActionResult SetupProfile(Profile profile) {
			profile.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

			return Redirect("~/Profile/" + dal.getUserFromID(GetCurrentUserID()).UserName);
		}

		private string GetCurrentUserID() {
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
