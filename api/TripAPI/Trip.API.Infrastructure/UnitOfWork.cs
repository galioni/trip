using Microsoft.EntityFrameworkCore;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }

		//IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
		//{
		//	throw new System.NotImplementedException();
		//}

		//int IUnitOfWork.Commit()
		//{
		//	throw new System.NotImplementedException();
		//}
	}
}
