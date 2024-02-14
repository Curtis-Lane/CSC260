using Microsoft.AspNetCore.Mvc;
using MoviesScaffoldID.Models;
using MoviesScaffoldID.Interfaces;
using MoviesScaffoldID.Data;

namespace MoviesScaffoldID.Controllers {
	public class MovieController : Controller {
		IDataAccessLayer dal;

		// Allows for dependency injection
		public MovieController(IDataAccessLayer dal) {
			this.dal = dal;
		}

		public IActionResult Index() {
			return View();
		}

		// Use a redirect for the loan function's return value that points back to the current page

		public IActionResult DisplayMovie() {
			//Movie m = new Movie("Tron", 1982, 4.7f, null, "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_FMjpg_UX1000_.jpg");
			return View(dal.GetMovies().Last());
		}

		public IActionResult MultMovies() {
			return View(dal.GetMovies());
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
				dal.AddMovie(m);
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
				Movie? m = dal.GetMovie((int)id);
				//Movie? m = MovieList.Find(x => x.ID == id);
				//Movie? m = MovieList.Where(x => x.ID == id).FirstOrDefault();
				if(m == null) {
					ViewData["Error"] = "Cannot find movie with id " + id.ToString();
				}
				return View(m);
			}
		}

		[HttpPost] // Save
		public IActionResult Edit(Movie m) {
			//int index = MovieList.FindIndex(x => x.ID == m.ID);
			//if(index != -1) {
			//	MovieList[index] = m;
			//	TempData["Success"] = "Movie \"" + m.Title + "\" updated";
			//} else {
			//	TempData["Success"] = "Failed to update movie \"" + m.Title + "\"";
			//}
			if(dal.UpdateMovie(m)) {
				TempData["Success"] = "Movie \"" + m.Title + "\" updated";
			} else {
				TempData["Success"] = "Failed to update movie \"" + m.Title + "\"";
			}
			return RedirectToAction("MultMovies", "Movie");
		}

		[HttpGet]
		public IActionResult Delete(int? id) {
			if(id == null) {
				ViewData["Error"] = "Movie id not found";
				return View();
			} else {
				Movie? m = dal.GetMovie((int)id);
				if(m == null) {
					ViewData["Error"] = "Cannot find movie with id " + id.ToString();
				}
				return View(m);
			}
		}

		[HttpPost]
		public IActionResult Delete(Movie m) {
			//int index = MovieList.FindIndex(x => x.ID == m.ID);
			//if(index != -1) {
			//	MovieList.RemoveAt(index);
			//	TempData["Success"] = "Movie \"" + m.Title + "\" deleted";
			//} else {
			//	TempData["Success"] = "Failed to delete movie \"" + m.Title + "\"";
			//}
			//	return RedirectToAction("MultMovies", "Movie");
			if(dal.RemoveMovie(m.ID)) {
				TempData["Success"] = "Movie \"" + m.Title + "\" deleted";
			} else {
				TempData["Success"] = "Failed to delete movie \"" + m.Title + "\"";
			}
			return RedirectToAction("MultMovies", "Movie");
		}

		[HttpPost]
		public IActionResult Search(string? key) {
			if(string.IsNullOrEmpty(key)) {
				return RedirectToAction("MultMovies", "Movie");
			} else {
				return View("MultMovies", dal.SearchForMovies(key));
			}
		}

		[HttpPost]
		public IActionResult Filter(string MPAARating, string Genre) {
			return View("MultMovies", dal.FilterMovies(MPAARating, Genre));
		}
	}
}
