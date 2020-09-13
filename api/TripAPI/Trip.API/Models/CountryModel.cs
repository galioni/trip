using System;
using System.ComponentModel.DataAnnotations;

namespace Trip.API.Models
{
	public class CountryModel
	{
		public int Id { get; set; }
		[Required]
		[StringLength(80)]
		public string Name { get; set; }
		[StringLength(3, MinimumLength = 3)]
		public string Code { get; set; }
		public bool IsActive { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}
