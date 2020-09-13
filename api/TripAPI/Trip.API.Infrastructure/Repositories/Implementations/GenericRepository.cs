using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trip.API.Infrastructure.Context;

namespace Trip.API.Infrastructure.Repositories
{
	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		internal TripDbContext context;
		internal DbSet<TEntity> dbSet;

		public GenericRepository(TripDbContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
				dbSet.Attach(entityToDelete);

			dbSet.Remove(entityToDelete);
		}

		public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					query = query.Include(includeProperty);
			}


			if (orderBy != null)
				return await orderBy(query).ToListAsync();
			else
				return await query.ToListAsync();
		}

		public virtual async Task<TEntity> GetByIDAsync(object id)
		{
			return await dbSet.FindAsync(id);
		}

		public virtual async Task<IEnumerable<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
		{
			return await dbSet.FromSqlRaw(query, parameters).ToListAsync();
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}
	}
}
