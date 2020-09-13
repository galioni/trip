using System.Threading.Tasks;
using Trip.API.Core;
using Trip.API.Core.Repositories;
using Trip.API.Data.Context;
using Trip.API.Implementations.Repositories;

namespace Trip.API.Data
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private readonly TripDbContext _context;
		private ICountryRepository _countryRepository;
		
		public UnitOfWork(TripDbContext context)
		{
			this._context = context;
		}

		public ICountryRepository Countries => _countryRepository = _countryRepository ?? new CountryRepository(_context);

		public async Task<int> CommitAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
