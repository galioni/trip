using System;
using System.Collections.Generic;
using System.Linq;
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
			this._unitOfWork = unitOfWork;
		}
		public async Task<Country> CreateCountry(Country newCountry)
		{
			await _unitOfWork.Countries
			   .AddAsync(newCountry);
			await _unitOfWork.CommitAsync();

			return newCountry;
		}

		public async Task DeleteCountry(Country Country)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Country>> GetAllCountries()
		{
			return await _unitOfWork.Countries.GetAllAsync();
		}

		public async Task<Country> GetCountryById(int id)
		{
			return await _unitOfWork.Countries.GetByIdAsync(id);
		}

		public async Task UpdateCountry(Country CountryToBeUpdated, Country Country)
		{
			throw new NotImplementedException();
		}

		public async Task<Country> GetByCodeAsync(string code)
		{
			return await _unitOfWork.Countries.SingleOrDefaultAsync(x => x.Code.ToUpper() == code.ToUpper());
		}
	}
}
