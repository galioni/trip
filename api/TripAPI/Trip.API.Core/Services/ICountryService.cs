using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.API.Core.Models;

namespace Trip.API.Core.Services.Interfaces
{
	public interface ICountryService
	{
		Task<Country> GetByCode(string code);
		Task<IEnumerable<Country>> GetAll();
		Task<Country> GetById(int id);
		Task<Country> CreateCountry(Country newCountry);
		Task UpdateCountry(Country CountryToBeUpdated, Country Country);
		Task DeleteCountry(int Id);
	}
}
