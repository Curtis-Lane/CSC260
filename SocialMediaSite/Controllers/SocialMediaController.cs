using Microsoft.AspNetCore.Mvc;

namespace SocialMediaSite.Controllers {
	public class SocialMediaController : Controller {
		public IActionResult AboutCreator() {
			return View();
		}
	}
}
