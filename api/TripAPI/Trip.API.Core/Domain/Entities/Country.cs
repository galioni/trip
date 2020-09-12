using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trip.API.Core.Domain.Entities
{
	[Table("Country")]
	public class Country
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsActive { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}
