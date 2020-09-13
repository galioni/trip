using System.Threading.Tasks;
using Trip.API.Core.Domain.Entities;
using Trip.API.Infrastructure.Entities;

namespace Trip.API.Infrastructure.Repositories
{
	public interface ICountryRepository
	{
		Task<Country> FindByCodeAsync(string code);
	}
}