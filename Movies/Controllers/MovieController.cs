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
			return View(/*m*/);
		}

		[HttpPost]
		public IActionResult Add(Movie m) {
			// Custom validation
			if(m.Title == "Cats") {
				ModelState.AddModelError("Title", "You are degenerate scum if you think you can add that movie to MY database!");
			}
			if(ModelState.IsValid) {
				MovieList.Add(m);
				return RedirectToAction("MultMovies", "Movie");
			} else {
				return View();
			}
		}

		[HttpGet] // Loading the edit page
		public IActionResult Edit(int? id) {
			if(id == null) {
				ViewData["Error"] = "Movie id not found";
				return View();
			} else {
				Movie? m = MovieList.Find(x => x.ID == id);
				//Movie? m = MovieList.Where(x => x.ID == id).FirstOrDefault();
				if(m == null) {
					ViewData["Error"] = "Cannot find movie with id " + id.ToString();
				}
				return View(m);
			}
		}

		[HttpPost] // Save
		public IActionResult Edit(Movie m) {
			int index = MovieList.FindIndex(x => x.ID == m.ID);
			if(index != -1) {
				MovieList[index] = m;
				TempData["Success"] = "Movie \"" + m.Title + "\" updated";
				return RedirectToAction("MultMovies", "Movie");
			} else {
				TempData["Success"] = "Failed to update movie \"" + m.Title + "\"";
				return RedirectToAction("MultMovies", "Movie");
			}
		}

		[HttpGet]
		public IActionResult Delete(int? id) {
			if(id == null) {
				ViewData["Error"] = "Movie id not found";
				return View();
			} else {
				Movie? m = MovieList.Find(x => x.ID == id);
				if(m == null) {
					ViewData["Error"] = "Cannot find movie with id " + id.ToString();
				}
				return View(m);
			}
		}

		[HttpPost]
		public IActionResult Delete(Movie m) {
			int index = MovieList.FindIndex(x => x.ID == m.ID);
			if(index != -1) {
				MovieList.RemoveAt(index);
				TempData["Success"] = "Movie \"" + m.Title + "\" deleted";
				return RedirectToAction("MultMovies", "Movie");
			} else {
				TempData["Success"] = "Failed to delete movie \"" + m.Title + "\"";
				return RedirectToAction("MultMovies", "Movie");
			}
		}
	}
}
