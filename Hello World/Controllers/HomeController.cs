using Hello_World.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hello_World.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() {
			return View();
		}

		public IActionResult Privacy() {
			//ViewData["Title"] = "Privacy set from controller";
			return View();
		}

		public IActionResult Contact() {
			return View();
		}

		public IActionResult Google() {
			return Redirect("https://google.com");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
