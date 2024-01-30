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
	}
}
