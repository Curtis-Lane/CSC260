using Movies.Models;
using MoviesDAL.Interfaces;

namespace MoviesDAL_DI.Data {
	public class LeastFavoriteMoviesDAL : IDataAccessLayer {
		private AppDbContext db;

		public LeastFavoriteMoviesDAL(AppDbContext db) {
			this.db = db;
		}

		//private static List<Movie> MovieList = new List<Movie>{
		//	new Movie("Bee Movie", 2007, 3.0f, null, "https://upload.wikimedia.org/wikipedia/en/5/5f/Bee_Movie_%282007_animated_feature_film%29.jpg"),
		//	new Movie("Mars Needs Moms", 2011, 0.5f, null, "https://upload.wikimedia.org/wikipedia/en/0/08/Mars_Needs_Moms%21_Poster.jpg"),
		//	new Movie("Sharknado", 2013, 2.5f, null, "https://upload.wikimedia.org/wikipedia/en/9/93/Sharknado_poster.jpg"),
		//	new Movie("The Last Airbender", 2010, 0.1f, null, "https://upload.wikimedia.org/wikipedia/en/8/8e/The_Last_Airbender_Poster.png"),
		//	new Movie("The Emoji Movie", 2017, 0.0f, null, "https://upload.wikimedia.org/wikipedia/en/6/63/The_Emoji_Movie_film_poster.jpg")
		//};

		public IEnumerable<Movie> GetMovies() {
			return db.Movies;
		}

		public IEnumerable<Movie> SearchForMovies(string key) {
			return db.Movies.Where(m => m.Title.ToLower().Contains(key.ToLower()));
		}

		public Movie? GetMovie(int ID) {
			//return MovieList.Find(m => m.ID == ID);
			return db.Movies.Find(ID);
		}

		public void AddMovie(Movie movie) {
			db.Movies.Add(movie);
			db.SaveChanges();
		}

		public bool UpdateMovie(Movie movie) {
			//int index = MovieList.FindIndex(m => m.ID == movie.ID);
			//if(index == -1) {
			//	return false;
			//} else {
			//	MovieList[index] = movie;
			//	return true;
			//}
			db.Movies.Update(movie);
			db.SaveChanges();
			return true;
		}

		public bool RemoveMovie(int ID) {
			Movie? movie = GetMovie(ID);
			if(movie == null) {
				return false;
			} else {
				db.Movies.Remove(movie);
				db.SaveChanges();
				return true;
			}
		}
	}
}