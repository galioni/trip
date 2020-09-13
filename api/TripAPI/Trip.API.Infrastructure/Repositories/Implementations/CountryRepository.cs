using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trip.API.Core.Domain.Entities;
using Trip.API.Infrastructure.Context;
using Trip.API.Infrastructure.Entities;

namespace Trip.API.Infrastructure.Repositories
{
	public class CountryRepository : GenericRepository<CountryEntity>, ICountryRepository
	{
		private readonly IMapper _mapper;
		TripDbContext _context;

		public CountryRepository(TripDbContext context, IMapper mapper)
			: base(context)
		{
			_context = context;
			_mapper = mapper;
		}

		public override void Delete(CountryEntity entityToDelete)
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

		public override async Task<IEnumerable<CountryEntity>> GetAsync(Expression<Func<CountryEntity, bool>> filter = null, Func<IQueryable<CountryEntity>, IOrderedQueryable<CountryEntity>> orderBy = null,
			string includeProperties = "")
		{
			return await _context.Countries.ToListAsync();
		}

		public override async Task<CountryEntity> GetByIDAsync(object id)
		{
			throw new NotImplementedException();
		}

		public override async Task<IEnumerable<CountryEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
		{
			throw new NotImplementedException();
		}

		public override void Insert(CountryEntity entity)
		{
			throw new NotImplementedException();
		}

		public override void Update(CountryEntity entityToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
