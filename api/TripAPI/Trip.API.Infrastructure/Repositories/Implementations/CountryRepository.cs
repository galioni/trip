using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trip.API.Infrastructure.Context;
using Trip.API.Infrastructure.Entities;

namespace Trip.API.Infrastructure.Repositories
{
	public class CountryRepository : GenericRepository<Country>, ICountryRepository
	{
		private readonly IMapper _mapper;
		TripDbContext _context;

		public CountryRepository(TripDbContext context, IMapper mapper)
			: base(context)
		{
			_context = context;
			_mapper = mapper;
		}

		public override void Delete(Country entityToDelete)
		{
			throw new NotImplementedException();
		}

		public override void Delete(object id)
		{
			throw new NotImplementedException();
		}

		public async Task<Country> FindByCodeAsync(string code)
		{
			var country = await _context.Countries.Where(x => x.Code.ToUpper() == code.ToUpper()).SingleOrDefaultAsync();

			if (country != null)
				return _mapper.Map<Country>(country);
			else
				return null;
		}

		public override async Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>> filter = null, Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy = null,
			string includeProperties = "")
		{
			return await _context.Countries.ToListAsync();
		}

		public override async Task<Country> GetByIDAsync(object id)
		{
			throw new NotImplementedException();
		}

		public override async Task<IEnumerable<Country>> GetWithRawSqlAsync(string query, params object[] parameters)
		{
			throw new NotImplementedException();
		}

		public override void Insert(Country entity)
		{
			throw new NotImplementedException();
		}

		public override void Update(Country entityToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
