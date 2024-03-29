﻿using System.ComponentModel.DataAnnotations;

namespace MoviesScaffoldID.Models {
	public class Genre {
		[Key]
		public int ID {get; set;}

		[Required]
		[MaxLength(100)]
		public string Title {get; set;}
	}
}
