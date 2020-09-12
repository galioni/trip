using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.API.Core.Domain.Entities;
using Trip.API.Core.Dto.GatewayResponses.Repositories;

namespace Trip.API.Core.Interfaces.Gateways.Repositories
{
	public interface ICountryRepository
	{
		Task<CreateCountryResponse> CreateAsync(Country country);
		Task<List<Country>> GetAsync();
		Task<Country> FindByIdAsync(int id);
		Task<Country> FindByNameAsync(string userName);
		Task<Country> FindByCodeAsync(string code);
	}
}
