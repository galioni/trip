using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Trip.API.Core.Models;
using Trip.API.Core.Repositories;
using Trip.API.Data.Context;
using Trip.API.Data.Repositories;

namespace Trip.API.Implementations.Repositories
{
	public class CountryRepository : Repository<Country>, ICountryRepository
	{
		public CountryRepository(TripDbContext context)
			: base(context)
		{
		}

		async Task<Country> ICountryRepository.FindByCodeAsync(string code)
		{
			return await Context.Set<Country>().SingleOrDefaultAsync(c => c.Code.ToUpper() == code.ToUpper());
		}
	}
}
