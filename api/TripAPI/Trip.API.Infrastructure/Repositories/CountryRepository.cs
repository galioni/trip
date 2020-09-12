using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.API.Core.Domain.Entities;
using Trip.API.Core.Dto.GatewayResponses.Repositories;
using Trip.API.Core.Interfaces.Gateways.Repositories;
using Trip.API.Infrastructure.Context;

namespace Trip.API.Infrastructure.Repositories
{
	public class CountryRepository : ICountryRepository
	{
		TripDbContext _context;

		public CountryRepository(TripDbContext context)
		{
			_context = context;
		}

		public async Task<CreateCountryResponse> CreateAsync(Country country)
		{
			throw new System.NotImplementedException();
		}

		public async Task<Country> FindByCodeAsync(string code)
		{
			
			return await _context.Countries.Where(x => x.Code.ToUpper() == code.ToUpper()).FirstOrDefaultAsync();
		}

		public async Task<Country> FindByIdAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<Country> FindByNameAsync(string userName)
		{
			throw new System.NotImplementedException();
		}

		public async Task<List<Country>> GetAsync()
		{
			return await _context.Countries.ToListAsync();
		}
	}
}
