using Movies.Models;
using MoviesDAL.Interfaces;

namespace MoviesDAL.Data {
	public class MovieListDAL : IDataAccessLayer {
		private static List<Movie> MovieList = new List<Movie>{
			new Movie("A Series of Unfortunate Events", 2004, 4.0f, null, "https://m.media-amazon.com/images/M/MV5BMjE3MDM4NTg0NV5BMl5BanBnXkFtZTcwNjI4MTczMw@@._V1_.jpg"),
			new Movie("Everything Everywhere All At Once", 2022, 4.5f, null, "https://upload.wikimedia.org/wikipedia/en/1/1e/Everything_Everywhere_All_at_Once.jpg"),
			new Movie("Spider-Man Across the Spider-Verse", 2023, 5.0f, null, "https://m.media-amazon.com/images/M/MV5BMzI0NmVkMjEtYmY4MS00ZDMxLTlkZmEtMzU4MDQxYTMzMjU2XkEyXkFqcGdeQXVyMzQ0MzA0NTM@._V1_.jpg"),
			new Movie("Tron", 1982, 4.7f, null, "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_FMjpg_UX1000_.jpg")
		};

		public IEnumerable<Movie> GetMovies() {
			return MovieList;
		}

		public Movie? GetMovie(int ID) {
			return MovieList.Find(m => m.ID == ID);
		}

		public void AddMovie(Movie movie) {
			MovieList.Add(movie);
		}

		public bool UpdateMovie(Movie movie) {
			int index = MovieList.FindIndex(m => m.ID == movie.ID);
			if(index == -1) {
				return false;
			} else {
				MovieList[index] = movie;
				return true;
			}
		}

		public bool RemoveMovie(int ID) {
			Movie? movie = GetMovie(ID);
			if(movie == null) {
				return false;
			} else {
				MovieList.Remove(movie);
				return true;
			}
		}
	}
}
