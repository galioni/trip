using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
		{ }

		public Task<Country> FindByCodeAsync(string code)
		{
			throw new NotImplementedException();
		}

		Task<Country> ICountryRepository.FindByCodeAsync(string code)
		{
			throw new NotImplementedException();
		}
	}
}
