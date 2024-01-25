using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Validation.Models;

namespace Validation.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() {
			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[HttpGet]
		public IActionResult ProfileForm() {
			return View();
		}

		[HttpPost]
		public IActionResult ProfileForm(ProfileData profile) {
			bool nullAddress = false;
			if(profile.Street == null) {
				nullAddress = true;
			}
			if(nullAddress) {
				if(profile.City != null || profile.State != null || profile.ZipCode != null) {
					ModelState.AddModelError("Street", "You can either leave all the address info blank, or you can fill in all of it. No inbetween.");
				}
			} else {
				if(profile.City == null || profile.State == null || profile.ZipCode == null) {
					ModelState.AddModelError("Street", "You can either leave all the address info blank, or you can fill in all of it. No inbetween.");
				}
			}

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
