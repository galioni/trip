using System.Threading.Tasks;

namespace Trip.API.Core.Services
{
	public interface IService<TEntity> where TEntity : class
	{
		Task DeleteCountry(TEntity Entity);
	}
}
