using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.API.Core.Models;
using Trip.API.Core.Services.Interfaces;

namespace Trip.API.Core.Services.Implementations
{
	public class CountryService : ICountryService
	{
		private readonly IUnitOfWork _unitOfWork;
		public CountryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Country> CreateCountry(Country newCountry)
		{
			await _unitOfWork.Countries.AddAsync(newCountry);
			await _unitOfWork.CommitAsync();

			return newCountry;
		}

		public async Task DeleteCountry(Country country)
		{
			_unitOfWork.Countries.Remove(country);

			await _unitOfWork.CommitAsync();
		}

		public async Task<IEnumerable<Country>> GetAllCountries()
		{
			return await _unitOfWork.Countries.GetAllAsync();
		}

		public async Task<Country> GetCountryById(int id)
		{
			return await _unitOfWork.Countries.GetByIdAsync(id);
		}
		public async Task<Country> GetByCodeAsync(string code)
		{
			return await _unitOfWork.Countries.SingleOrDefaultAsync(x => x.Code.ToUpper() == code.ToUpper());
		}

		public async Task UpdateCountry(Country countryToBeUpdated, Country Country)
		{
			countryToBeUpdated.Name = Country.Name;
			countryToBeUpdated.Code = Country.Code;
			countryToBeUpdated.Modified = DateTime.UtcNow;

			await _unitOfWork.CommitAsync();
		}
	}
}
