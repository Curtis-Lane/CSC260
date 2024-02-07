using Movies.Models;

namespace MoviesDAL.Interfaces {
	public interface IDataAccessLayer {
		IEnumerable<Movie> GetMovies();

		IEnumerable<Movie> SearchForMovies(string key);

		IEnumerable<Movie> FilterMovies(string MPAARating, string Genre);

		Movie? GetMovie(int ID);

		void AddMovie(Movie movie);

		bool UpdateMovie(Movie movie);

		bool RemoveMovie(int ID);
	}
}
