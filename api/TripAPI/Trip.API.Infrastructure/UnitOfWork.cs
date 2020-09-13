using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.API.Infrastructure.Context;
using Trip.API.Infrastructure.Entities;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Infrastructure
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private readonly TripDbContext _context = null;
		public Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

		public UnitOfWork(TripDbContext context)
		{
			this._context = context;
		}

		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			if (_repositories.Keys.Contains(typeof(T)) == true)
				return _repositories[typeof(T)] as IRepository<T>;

			IRepository<T> repo = new Repository<T>(_context);
			_repositories.Add(typeof(T), repo);

			return repo;
		}

		public int Commit()
		{
			return _context.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
