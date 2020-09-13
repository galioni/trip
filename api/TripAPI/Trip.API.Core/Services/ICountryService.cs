using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.API.Core.Models;

namespace Trip.API.Core.Services.Interfaces
{
	public interface ICountryService
	{
		Task<Country> GetByCodeAsync(string code);
		Task<IEnumerable<Country>> GetAllCountries();
		Task<Country> GetCountryById(int id);
		Task<Country> CreateCountry(Country newCountry);
		Task UpdateCountry(Country CountryToBeUpdated, Country Country);
		Task DeleteCountry(Country Country);
	}
}
