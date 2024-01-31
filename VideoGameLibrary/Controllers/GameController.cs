using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers {
	public class GameController : Controller {
		IDataAccessLayer dal = new GameCollectionDAL();

		[HttpGet]
		public IActionResult Collection() {
			return View(dal.GetCollection());
		}

		[HttpPost]
		public IActionResult Collection(int ID, string? LoanedTo) {
			dal.RentGame(ID, LoanedTo);

			return View(dal.GetCollection());
		}

		[HttpGet]
		public IActionResult Add() {
			return View();
		}

		[HttpPost]
		public IActionResult Add(VideoGame game) {
			if(ModelState.IsValid) {
				dal.AddGame(game);
				return RedirectToAction("Collection", "Game");
			} else {
				return View();
			}
		}

		[HttpGet]
		public IActionResult Edit(int? id) {
			if(id == null) {
				ViewData["Error"] = "Movie id not found";
				return View();
			} else {
				VideoGame? game = dal.GetGame((int) id);
				if(game == null) {
					ViewData["Error"] = "Cannot find movie with id " + id.ToString();
				}
				return View(game);
			}
		}

		[HttpPost]
		public IActionResult Edit(VideoGame game) {
			if(ModelState.IsValid) {
				if(dal.EditGame(game)) {
					TempData["Success"] = "Game \"" + game.Title + "\" updated";
				} else {
					TempData["Success"] = "Failed to update game \"" + game.Title + "\"";
				}
				return RedirectToAction("Collection", "Game");
			} else {
				return View();
			}
		}

		[HttpGet]
		public IActionResult Delete(int? id) {
			if(id == null) {
				ViewData["Error"] = "Game id not found";
				return View();
			} else {
				VideoGame? game = dal.GetGame((int) id);
				if(game == null) {
					ViewData["Error"] = "Cannot find movie with id " + id.ToString();
				}
				return View(game);
			}
		}

		[HttpPost]
		public IActionResult Delete(VideoGame game) {
			if(dal.DeleteGame(game.ID)) {
				TempData["Success"] = "Game \"" + game.Title + "\" deleted";
			} else {
				TempData["Success"] = "Failed to delete game \"" + game.Title + "\"";
			}
			return RedirectToAction("Collection", "Game");
		}

		[HttpPost]
		public IActionResult Search(string? key) {
			if(string.IsNullOrEmpty(key)) {
				return RedirectToAction("Collection", "Game");
			} else {
				return View("Collection", dal.SearchForGames(key));
			}
		}
	}
}
