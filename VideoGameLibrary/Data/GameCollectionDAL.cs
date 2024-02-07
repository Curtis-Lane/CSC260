using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Data {
	public class GameCollectionDAL : IDataAccessLayer {
		private static List<VideoGame> GameCollection = new List<VideoGame>{
			new VideoGame("Team Fortress 2", "PC", "FPS", "M", 2007, "https://upload.wikimedia.org/wikipedia/en/5/5f/Tf2_standalonebox.jpg"),
			new VideoGame("Deep Rock Galactic", "PC, Xbox Series, Playstation 5", "FPS", "T", 2020, "https://upload.wikimedia.org/wikipedia/en/b/b3/Deep_rock_galactic_cover_art.jpg"),
			new VideoGame("Payday 2", "PC", "FPS", "M", 2013, "https://upload.wikimedia.org/wikipedia/en/7/7b/Payday2cover.jpg"),
			new VideoGame("Terraria", "PC, Xbox Series, Playstation 5, Mobile", "Side-scroller", "T", 2011, "https://upload.wikimedia.org/wikipedia/en/1/1a/Terraria_Steam_artwork.jpg"),
			new VideoGame("Grand Theft Auto V", "PC, Xbox Series, Playstation 5", "FPS", "M", 2013, "https://upload.wikimedia.org/wikipedia/en/a/a5/Grand_Theft_Auto_V.png")
		};

		public GameCollectionDAL() {
			int id = 0;
			foreach(VideoGame videoGame in GameCollection) {
				videoGame.ID = id++;
			}
		}

		public IEnumerable<VideoGame> GetCollection() {
			return GameCollection;
		}

		public IEnumerable<VideoGame> SearchForGames(string key) {
			return GameCollection.Where(g => g.Title.ToLower().Contains(key.ToLower()));
		}

		public IEnumerable<VideoGame> FilterCollection(string? Genre = null, string? Platform = null, string? ESRBRating = null) {
			if(Genre == null) {
				Genre = string.Empty;
			}
			if(Platform == null) {
				Platform = string.Empty;
			}
			if(ESRBRating == null) {
				ESRBRating = string.Empty;
			}

			if(Genre == string.Empty && Platform == string.Empty && ESRBRating == string.Empty) {
				return GetCollection();
			}

			IEnumerable<VideoGame> lstGamesByGenre = GetCollection().Where(g => (!string.IsNullOrEmpty(g.Genre) && g.Genre.ToLower().Contains(Genre.ToLower()))).ToList();

			IEnumerable<VideoGame> lstGamesByPlatform = GetCollection().Where(g => (!string.IsNullOrEmpty(g.Platform) && g.Platform.ToLower().Contains(Platform.ToLower()))).ToList();

			IEnumerable<VideoGame> lstGamesByESRB = GetCollection().Where(g => (!string.IsNullOrEmpty(g.ESRBRating) && g.ESRBRating.ToLower().Contains(ESRBRating.ToLower()))).ToList();

			return lstGamesByGenre.Intersect(lstGamesByPlatform).Intersect(lstGamesByESRB);
		}

		public VideoGame? GetGame(int ID) {
			return GameCollection.Find(g => g.ID == ID);
		}

		public void RentGame(int ID, string? LoanedTo) {
			VideoGame videoGame = GetGame(ID);
			if(string.IsNullOrEmpty(LoanedTo)) {
				videoGame.LoanedTo = null;
				videoGame.LoanDate = null;
			} else {
				videoGame.LoanedTo = LoanedTo;
				videoGame.LoanDate = DateTime.Now;
			}
		}

		public void AddGame(VideoGame game) {
			GameCollection.Add(game);
		}

		public bool EditGame(VideoGame game) {
			int index = GameCollection.FindIndex(g => g.ID == game.ID);
			if(index == -1) {
				return false;
			} else {
				GameCollection[index] = game;
				return true;
			}
		}

		public bool DeleteGame(int ID) {
			VideoGame? game = GetGame(ID);
			if(game == null) {
				return false;
			} else {
				GameCollection.Remove(game);
				return true;
			}
		}
	}
}
