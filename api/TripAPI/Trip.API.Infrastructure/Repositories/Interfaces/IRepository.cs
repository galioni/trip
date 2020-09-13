﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Trip.API.Infrastructure.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		void Delete(TEntity entityToDelete);
		void Delete(object id);

		Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");
		Task<TEntity> GetByIDAsync(object id);
		Task<IEnumerable<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters);

		void Insert(TEntity entity);
		void Update(TEntity entityToUpdate);
	}
}
