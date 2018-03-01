using System.ComponentModel.DataAnnotations;

namespace Web2Rpm.Models
{
	public class Lead
	{
		[Required]
		public string Company { get; set; }

		[Required]
		public string Name { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		public string Phone { get; set; }

		public string Website { get; set; }

		[Display(Name = "Questions / Comments")]
		public string Comment { get; set; }

	}
}
