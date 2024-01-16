namespace Movies.Models {
	public class Movie {
		private static int nextID = 0;
		public int? ID {get; set;} = nextID++;

		public string Title {get; set;}

		public int? Year {get; set;}

		public float? Rating {get; set;}

		public DateTime? ReleaseDate {get; set;}

		public string Image {get; set;}

		// ALWAYS NEEDED (For MVC)
		public Movie() {;}

		public Movie(string Title, int? Year, float? Rating, DateTime? ReleaseDate, string Image) {
			this.Title = Title;
			this.Year = Year;
			this.Rating = Rating;
			this.ReleaseDate = ReleaseDate;
			this.Image = Image;
		}
	}
}
