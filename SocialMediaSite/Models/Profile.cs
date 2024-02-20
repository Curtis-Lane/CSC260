using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models {
	public class Profile {
		[Key]
		public int ID {get; set;}

		[Required]
		public string ProfilePicture {get; set;}

		[Required]
		[MaxLength(250)]
		public string Name {get; set;}

		[Required]
		[MaxLength(100)]
		public string FavAnime {get; set;}

		[Required]
		[MaxLength(50)]
		public string FavAnimeEpisode {get; set;}

		[Required]
		[MaxLength(100)]
		public string LeastFavAnime {get; set;}

		[Required]
		[MaxLength(450)]
		public string UserID {get; set;}
		[Required]
		public virtual IdentityUser User {get; set;}
	}
}