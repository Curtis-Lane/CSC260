using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Diagnostics;

namespace Routing.Controllers {
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

        public IActionResult Chicken() {
            return Redirect("https://www.chick-fil-a.com");
        }

        public IActionResult DefaultCow(int mooCount) {
            return Content("The cow Default Cow moos at you " + mooCount.ToString() + " times.");
        }

        public IActionResult NamedCow(int mooCount, string cowName) {
            return Content("The cow " + cowName + " moos at you " + mooCount.ToString() + " times.");
        }

        public IActionResult AllCowsCount(int cowCount) {
            return Content("There are " + cowCount.ToString() + " Cows on page");
        }

		public IActionResult AllCowsCountPerPage(int cowCount, int pageNumber) {
			return Content("There are " + cowCount.ToString() + " cows per page, on page " + pageNumber.ToString());
		}

		public IActionResult AllCowsCountOnPage(int cowCount, int pageNumber) {
			return Content("There are " + cowCount.ToString() + " Cows on page " + pageNumber.ToString());
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
