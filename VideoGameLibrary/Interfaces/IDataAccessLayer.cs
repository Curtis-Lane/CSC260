using VideoGameLibrary.Models;

namespace VideoGameLibrary.Interfaces {
	public interface IDataAccessLayer {
		IEnumerable<VideoGame> GetCollection();

		IEnumerable<VideoGame> SearchForGames(string key);

		void RentGame(int ID, string? LoanedTo);

		void AddGame(VideoGame game);

		bool EditGame(VideoGame game);

		bool DeleteGame(int ID);
	}
}
