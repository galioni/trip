using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Api.Service;
using Trip.API.Core.Exceptions;
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

		private async Task Validate(ValidationType actionType, Country country)
		{
			if (actionType != ValidationType.Insert)
			{
				var validCountry = await GetById(country.Id);
				if (validCountry == null)
					throw new BusinessException($"Country not found.", BusinessErrorCodes.NotFound);
			}

			if (actionType != ValidationType.Delete)
			{
				var countryExists = await GetByName(country.Name);
				if (countryExists != null)
					throw new BusinessException($"Country {country.Name} already exists.", BusinessErrorCodes.AlreadyExists);

				countryExists = await GetByCode(country.Code);
				if (countryExists != null)
					throw new BusinessException($"Country with {country.Code} code already exists.", BusinessErrorCodes.AlreadyExists);
			}
		}

		public async Task<Country> CreateCountry(Country newCountry)
		{
			await Validate(ValidationType.Insert, newCountry);

			await _unitOfWork.Countries.AddAsync(newCountry);
			await _unitOfWork.CommitAsync();

			newCountry = await GetById(newCountry.Id);

			return newCountry;
		}

		public async Task DeleteCountry(int Id)
		{
			var country = new Country() { Id = Id };
			await Validate(ValidationType.Delete, country);

			_unitOfWork.Countries.Remove(country);
			await _unitOfWork.CommitAsync();
		}

		public async Task<IEnumerable<Country>> GetAll()
		{
			return await _unitOfWork.Countries.GetAllAsync();
		}

		public async Task<Country> GetById(int id)
		{
			return await _unitOfWork.Countries.GetByIdAsync(id);
		}
		public async Task<Country> GetByCode(string code)
		{
			return await _unitOfWork.Countries.FindByCodeAsync(code);
		}

		public async Task<Country> GetByName(string name)
		{
			return await _unitOfWork.Countries.SingleOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());
		}

		public async Task UpdateCountry(Country countryToBeUpdated, Country Country)
		{
			await Validate(ValidationType.Delete, Country);

			countryToBeUpdated.Name = Country.Name;
			countryToBeUpdated.Code = Country.Code;
			countryToBeUpdated.Modified = DateTime.UtcNow;

			await _unitOfWork.CommitAsync();
		}
	}
}
