using Movies.Validators;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models {
	[EightiesMovieRatings]
	public class Movie {
		private static int nextID = 0;
		public int? ID {get; set;} = nextID++;

		[Required(ErrorMessage = "Movie Title is required, dummy")]
		[MaxLength(213)]
		public string Title {get; set;}

		[Required]
		public int? Year {get; set;}

		[Range(1.0f, 5.0f, ErrorMessage = "Rating is out of bounds")]
		public float? Rating {get; set;}

		public DateTime? ReleaseDate {get; set;}

		[Required]
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
