using System.ComponentModel.DataAnnotations;

namespace Validation.Models {
	public class ProfileData {
		[Required(ErrorMessage = "The user's name is a required field, please enter it")]
		public string? Name {get; set;}

		[Required(ErrorMessage = "The user's age is a required field, please enter it")]
		[Range(5, double.MaxValue, ErrorMessage = "Users less than 5 years of age are not allowed on this site")]
		public int? Age {get; set;}

		public string? Street {get; set;}

		public string? City {get; set;}

		public string? State {get; set;}

		public int? ZipCode {get; set;}

		public ProfileData() {;}

		public ProfileData(string Name, int Age, string? Street, string? City, string? State, int? ZipCode) {
			this.Name = Name;
			this.Age = Age;
			this.Street = Street;
			this.City = City;
			this.State = State;
			this.ZipCode = ZipCode;
		}
	}
}
