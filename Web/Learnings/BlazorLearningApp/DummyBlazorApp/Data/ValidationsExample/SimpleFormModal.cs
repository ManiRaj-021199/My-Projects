using System.ComponentModel.DataAnnotations;

namespace DummyBlazorApp.Data.ValidationsExample
{
	public class SimpleFormModal
	{
		[Required (ErrorMessage = "Name Required.")]
		public string? Name { get; set; }

		[Range (18, 50, ErrorMessage = "Age Should be Above 18 and Below 50.")]
		public int Age { get; set; }

		[Required (ErrorMessage = "Email Required.")]
		[DataType (DataType.EmailAddress)]
		[EmailAddress (ErrorMessage = "Enter Valid Email Id.")]
		public string? Email { get; set; }

		[Required (ErrorMessage = "City Name Required.")]
		[StringLength (10, ErrorMessage = "City name length shouldn't cross 10.")]
		public string? City { get; set; }
	}
}
