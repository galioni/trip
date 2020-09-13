using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Trip.API.Core.Repositories;
using Trip.API.Infrastructure;
using Trip.API.Infrastructure.Entities;
using Trip.API.Models;

namespace Trip.API.Controllers
{
	[ApiController]
	[Route("country")]
	public class CountryController : ControllerBase
	{
		private readonly ILogger<CountryController> _logger;
		private ICountryRepository _countryRepository = null;

		public CountryController(ILogger<CountryController> logger, ICountryRepository countryRepository)
		{
			_logger = logger;
			_countryRepository = countryRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var countries = await _countryRepository.GetAsync();

			return new OkObjectResult(countries);
		}

		[HttpGet("{code}")]
		public async Task<IActionResult> Get(string code)
		{
			var countries = await _countryRepository.FindByCodeAsync(code);

			return new OkObjectResult(countries);
		}

		[HttpPost]
		public async Task<IActionResult> Post(CountryModel model)
		{
			if (ModelState.IsValid)
			{
				var countryEntity = new CountryEntity()
				{
					Code = model.Code.ToUpper(),
					IsActive = true,
					Name = model.Name
				};

				_countryRepository.Insert(countryEntity);

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
				
				var countryEntity = new CountryEntity()
				{
					Code = model.Code.ToUpper(),
					IsActive = true,
					Name = model.Name
				};

				_countryRepository.Update(countryEntity);

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
				if (id == 0)
					throw new Exception("Parameter ID is mandatory");

				_countryRepository.Delete(id);

				return new OkResult();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
