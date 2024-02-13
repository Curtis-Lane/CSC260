using IDNewProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace IDNewProject.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() {
			return View();
		}

		[Authorize] // Can be used on methods or classes
		public IActionResult Privacy() {
			//ViewBag.ID = User.FindFirstValue(ClaimTypes.Name); // Username
			//ViewBag.ID = User.FindFirstValue(ClaimTypes.Email); // Email
			ViewBag.ID = User.FindFirstValue(ClaimTypes.NameIdentifier); // UserID
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
