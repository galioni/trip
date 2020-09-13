using System.Threading.Tasks;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Infrastructure
{
	public interface IUnitOfWork
	{
		IRepository<T> GetRepository<T>() where T : class;

		int Commit();

		Task<int> CommitAsync();
	}
}
