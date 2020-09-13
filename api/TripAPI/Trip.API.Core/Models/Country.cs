using System;

namespace Trip.API.Core.Models
{
	public class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsActive { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}
