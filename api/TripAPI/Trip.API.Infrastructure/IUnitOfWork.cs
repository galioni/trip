using Microsoft.EntityFrameworkCore;
using System;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Infrastructure
{
	public interface IUnitOfWork : IDisposable
    {
        //IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        //int Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
