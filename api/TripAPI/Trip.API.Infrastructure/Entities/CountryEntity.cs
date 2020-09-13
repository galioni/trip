using System.ComponentModel.DataAnnotations.Schema;

namespace Trip.API.Infrastructure.Entities
{
	[Table("Country")]
	public class CountryEntity : BaseEntity
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsActive { get; set; }
	}
}
