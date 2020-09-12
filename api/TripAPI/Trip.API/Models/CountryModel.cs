using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.API.Models
{
	public class CountryModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsActive { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}
