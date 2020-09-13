using System;
using System.Threading.Tasks;
using Trip.API.Core.Repositories;

namespace Trip.API.Core
{
	public interface IUnitOfWork : IDisposable
	{
		ICountryRepository Countries {get;}
		Task<int> CommitAsync();
	}
}
