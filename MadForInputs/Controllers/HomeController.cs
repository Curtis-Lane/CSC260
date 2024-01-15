using MadForInputs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MadForInputs.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Input() {
			return View();
		}

		[HttpPost]
		public IActionResult Output(string exclamation, string number, string adverb, string noun, string adjective) {
			ViewBag.EX = exclamation;
			ViewBag.NU = number;
			ViewBag.AV = adverb;
			ViewBag.NO = noun;
			ViewBag.AJ = adjective;
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
