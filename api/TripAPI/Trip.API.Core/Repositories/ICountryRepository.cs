using System.Threading.Tasks;
using Trip.API.Core.Models;

namespace Trip.API.Core.Repositories
{
	public interface ICountryRepository : IRepository<Country>
	{
		Task<Country> FindByCodeAsync(string code);
	}
}