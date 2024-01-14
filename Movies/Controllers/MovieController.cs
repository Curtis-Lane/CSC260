using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers {
	public class MovieController : Controller {
		private static List<Movie> MovieList = new List<Movie>{
			new Movie("A Series of Unfortunate Events", 2004, 4.0f),
			new Movie("Everything Everywhere All At Once", 2022, 4.5f),
			new Movie("Spider-Man Across the Spider-Verse", 2023, 5.0f)
		};

		public IActionResult Index() {
			return View();
		}

		public IActionResult DisplayMovie() {
			Movie m = new Movie("Tron", 1982, 4.7f);
			return View(m);
		}

		public IActionResult MultMovies() {
			return View(MovieList);
		}
	}
}
