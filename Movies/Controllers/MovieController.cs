using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers {
	public class MovieController : Controller {
		private static List<Movie> MovieList = new List<Movie>{
			new Movie("A Series of Unfortunate Events", 2004, 4.0f, null, "https://m.media-amazon.com/images/M/MV5BMjE3MDM4NTg0NV5BMl5BanBnXkFtZTcwNjI4MTczMw@@._V1_.jpg"),
			new Movie("Everything Everywhere All At Once", 2022, 4.5f, null, "https://upload.wikimedia.org/wikipedia/en/1/1e/Everything_Everywhere_All_at_Once.jpg"),
			new Movie("Spider-Man Across the Spider-Verse", 2023, 5.0f, null, "https://m.media-amazon.com/images/M/MV5BMzI0NmVkMjEtYmY4MS00ZDMxLTlkZmEtMzU4MDQxYTMzMjU2XkEyXkFqcGdeQXVyMzQ0MzA0NTM@._V1_.jpg")
		};

		public IActionResult Index() {
			return View();
		}

		// Use a redirect for the loan function's return value that points back to the current page

		public IActionResult DisplayMovie() {
			Movie m = new Movie("Tron", 1982, 4.7f, null, "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_FMjpg_UX1000_.jpg");
			return View(m);
		}

		public IActionResult MultMovies() {
			return View(MovieList);
		}

		[HttpGet]
		public IActionResult Add() {
			//Movie m = new Movie("Shrek 2", 2004, 5.0f, null, "https://m.media-amazon.com/images/M/MV5BNjAyYjg2MzctNWM0NS00ODE4LTg4NTEtZWM4MDk5ZWVlODEyXkEyXkFqcGdeQXVyNjc0NTEzOTA@._V1_.jpg");
			return View();
		}

		[HttpPost]
		public IActionResult Add(Movie m) {
			MovieList.Add(m);
			return RedirectToAction("MultMovies", "Movie");
			//return View();
		}
	}
}
