using Microsoft.AspNetCore.Mvc;
using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SocialMediaSite.Controllers {
	public class HomeController : Controller {
		//private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger) {
		//	_logger = logger;
		//}

		IDataAccessLayer dal;

		public HomeController(IDataAccessLayer dal) {
			this.dal = dal;
		}

		public IActionResult Index() {
			if(GetCurrentUserID() == null) {
				return View();
			} else {
				return Redirect("~/Profile/" + dal.getUserFromID(GetCurrentUserID()));
			}
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}

		private string GetCurrentUserID() {
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
