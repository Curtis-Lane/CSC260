using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models {
	public class Post {
		[Key]
		public int ID {get; set;}

		[Required]
		[MaxLength(150)]
		public string Contents {get; set;}

		[Required]
		public int PosterID {get; set;}

		[Required]
		public int PostedOnID {get; set;}

		[Required]
		public DateTime PostDate {get; set;}
	}
}