using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models {
	public class Image {
		[Key]
		public int ID {get; set;}

		[Required]
		public string URL {get; set;}

		[Required]
		public int ProfileID {get; set;}
		[Required]
		public virtual Profile Profile {get; set;}
	}
}
