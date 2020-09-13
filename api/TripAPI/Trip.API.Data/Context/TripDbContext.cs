using Microsoft.EntityFrameworkCore;
using Trip.API.Core.Models;
using Trip.API.Data.Configurations;

namespace Trip.API.Data.Context
{
	public class TripDbContext : DbContext
	{
		public DbSet<Country> Countries { set; get; }

		public TripDbContext(DbContextOptions<TripDbContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.ApplyConfiguration(new CountryConfiguration());
		}
	}
}
