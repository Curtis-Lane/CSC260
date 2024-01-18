using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers {
	public class GameController : Controller {
		private static List<VideoGame> videoGames = new List<VideoGame>{
			new VideoGame("Team Fortress 2", "PC", "FPS", "M", 2007, "https://upload.wikimedia.org/wikipedia/en/5/5f/Tf2_standalonebox.jpg"),
			new VideoGame("Deep Rock Galactic", "PC, Xbox Series, Playstation 5", "FPS", "T", 2020, "https://upload.wikimedia.org/wikipedia/en/b/b3/Deep_rock_galactic_cover_art.jpg"),
			new VideoGame("Payday 2", "PC", "FPS", "M", 2013, "https://upload.wikimedia.org/wikipedia/en/7/7b/Payday2cover.jpg"),
			new VideoGame("Terraria", "PC, Xbox Series, Playstation 5, Mobile", "Side-scroller", "T", 2011, "https://upload.wikimedia.org/wikipedia/en/1/1a/Terraria_Steam_artwork.jpg"),
			new VideoGame("Grand Theft Auto V", "PC, Xbox Series, Playstation 5", "FPS", "M", 2013, "https://upload.wikimedia.org/wikipedia/en/a/a5/Grand_Theft_Auto_V.png")
		};

		[HttpGet]
		public IActionResult Collection() {
			return View(videoGames);
		}

		[HttpPost]
		public IActionResult Collection(int ID, string? LoanedTo) {
			if(LoanedTo != null) {
				VideoGame videoGame = videoGames.Find(x => x.ID == ID);
				videoGame.LoanedTo = LoanedTo;
				videoGame.LoanDate = DateTime.Now;
			} else {
				VideoGame videoGame = videoGames.Find(x => x.ID == ID);
				videoGame.LoanedTo = null;
				videoGame.LoanDate = null;
			}

			return View(videoGames);
		}
	}
}
