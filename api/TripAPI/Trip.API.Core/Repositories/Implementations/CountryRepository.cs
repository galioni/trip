using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trip.API.Infrastructure;
using Trip.API.Infrastructure.Context;
using Trip.API.Infrastructure.Entities;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Core.Repositories
{
	public class CountryRepository : Repository<CountryEntity>, ICountryRepository
	{
		private readonly IMapper _mapper;
		private IUnitOfWork _unitOfWork;
		TripDbContext _context;

		public CountryRepository(TripDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
			: base(context)
		{
			_context = context;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public override void Delete(CountryEntity entityToDelete)
		{
			_context.Remove(entityToDelete);
			_unitOfWork.Commit();
		}

		public override async void Delete(object id)
		{
			var country = await FindByCodeAsync("Ita");
			Delete(country);
		}

		public async Task<CountryEntity> FindByCodeAsync(string code)
		{
			var country = await _context.Countries.Where(x => x.Code.ToUpper() == code.ToUpper()).SingleOrDefaultAsync();

			if (country != null)
				return _mapper.Map<CountryEntity>(country);
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
			_context.Add(entity);
			_unitOfWork.Commit();
		}

		public override void Update(CountryEntity entityToUpdate)
		{
			_context.Update(entityToUpdate);
			_unitOfWork.Commit();
		}
	}
}
