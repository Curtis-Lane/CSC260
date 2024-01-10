namespace Movies.Models {
	public class Movie {
		private static int nextID = 0;
		public int? ID {get; set;} = nextID++;

		public string Title {get; set;}

		public int? Year {get; set;}

		public float? Rating {get; set;}

		// ALWAYS NEEDED (For MVC)
		public Movie() {;}

		public Movie(string Title, int? Year, float? Rating) {
			this.Title = Title;
			this.Year = Year;
			this.Rating = Rating;
		}
	}
}
