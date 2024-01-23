namespace VideoGameLibrary.Models {
	public class VideoGame {
		private static int nextID = 1;
		public int ID {get; set;} = nextID++;

		public string Title {get; set;}

		public string Platform {get; set;}

		public string Genre {get; set;}

		public string ESRBRating {get; set;}

		public int Year {get; set;}

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
