using System.Threading.Tasks;
using Trip.API.Infrastructure.Entities;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Core.Repositories
{
	public interface ICountryRepository : IRepository<CountryEntity>
	{
		Task<CountryEntity> FindByCodeAsync(string code);
	}
}