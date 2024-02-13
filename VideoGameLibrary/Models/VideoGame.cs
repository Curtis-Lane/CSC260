using System.ComponentModel.DataAnnotations;

namespace VideoGameLibrary.Models {
	public class VideoGame {
		[Key]
		public int ID {get; set;}

		[Required(ErrorMessage = "The game's title is a required field!")]
		public string Title {get; set;}

		[Required(ErrorMessage = "The game's platform is a required field!")]
		public string Platform {get; set;}

		[Required(ErrorMessage = "The game's genre is a required field!")]
		public string Genre {get; set;}

		[Required(ErrorMessage = "The game's ESRB rating is a required field!")]
		public string ESRBRating {get; set;}

		[Required(ErrorMessage = "The game's year is a required field!")]
		[Range(1970, int.MaxValue, ErrorMessage = "I'm pretty sure video games didn't exist before 1970!")]
		public int? Year {get; set;}

		[Required(ErrorMessage = "A link to the game's cover image is required!")]
		public string Image {get; set;}

		public string? LoanedTo {get; set;} = null;
		
		public DateTime? LoanDate {get; set;} = null;

		public VideoGame() {;}

		public VideoGame(string Title, string Platform, string Genre, string ESRBRating, int Year, string Image) {
			this.Title = Title;
			this.Platform = Platform;
			this.Genre = Genre;
			this.ESRBRating = ESRBRating;
			this.Year = Year;
			this.Image = Image;
		}
	}
}
