using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trip.API.Infrastructure.Entities;

namespace Trip.API.Infrastructure.Context
{
	public class TripDbContext : DbContext
	{
		public TripDbContext(DbContextOptions<TripDbContext> options)
			: base(options)
		{
		}

		public DbSet<Country> Countries { set; get; }

		public override int SaveChanges()
		{
			AddAuditInfo();
			return base.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			AddAuditInfo();
			return await base.SaveChangesAsync();
		}

		private void AddAuditInfo()
		{
			var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State.Equals(EntityState.Added) || x.State.Equals(EntityState.Modified)));
			foreach (var entry in entries)
			{
				if (entry.State.Equals(EntityState.Added))
					((BaseEntity)entry.Entity).Created = DateTime.UtcNow;

				((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
			}
		}
	}
}
