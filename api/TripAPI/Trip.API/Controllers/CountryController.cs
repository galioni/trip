using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.API.Core.Models;
using Trip.API.Core.Services.Interfaces;
using Trip.API.Models;
using Trip.API.Resources;

namespace Trip.API.Controllers
{
	[ApiController]
	[Route("country")]
	public class CountryController : ControllerBase
	{
		private readonly ILogger<CountryController> _logger;
		private readonly IMapper _mapper;
		private readonly ICountryService _countryService;

		public CountryController(ILogger<CountryController> logger, IMapper mapper, ICountryService countryService)
		{
			_logger = logger;
			_mapper = mapper;
			_countryService = countryService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var countries = await _countryService.GetAllCountries();
			var countriesResources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);

			return new OkObjectResult(countriesResources);
		}

		[HttpGet("{code}")]
		public async Task<IActionResult> Get(string code)
		{
			var countries = await _countryService.GetByCodeAsync(code);

			return new OkObjectResult(countries);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCountry(CountryModel model)
		{
			if (ModelState.IsValid)
			{
				//var countryEntity = new CountryEntity()
				//{
				//	Code = model.Code.ToUpper(),
				//	IsActive = true,
				//	Name = model.Name
				//};

				//_countryRepository.Insert(countryEntity);

				return new OkResult();
			}
			else
			{
				return BadRequest();
			}
			
		}

		[HttpPut]
		public async Task<IActionResult> Put(CountryModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.Id == 0)
					throw new Exception("Parameter ID is mandatory");
				
				//var countryEntity = new CountryEntity()
				//{
				//	Code = model.Code.ToUpper(),
				//	IsActive = true,
				//	Name = model.Name
				//};

				//_countryRepository.Update(countryEntity);

				return new OkResult();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (ModelState.IsValid)
			{
				//if (id == 0)
				//	throw new Exception("Parameter ID is mandatory");

				//_countryRepository.Delete(id);

				return new OkResult();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
