using Movies.Models;
using System.ComponentModel.DataAnnotations;

namespace Movies.Validators {
	// Custom Validations across fields or models
	// Must end with "Attribute"
	public class EightiesMovieRatingsAttribute : ValidationAttribute {
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
			Movie movie = (Movie) validationContext.ObjectInstance;
			if(movie.Year >= 1980 && movie.Year < 1990 && movie.Rating < 2.5f) {
				return new ValidationResult("MOVIES CANNOT BE BAD IN THE 80s!");
			} else {
				return ValidationResult.Success;
			}
		}
	}
}
