using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.API.Core.Exceptions;
using Trip.API.Core.Models;
using Trip.API.Core.Services.Interfaces;
using Trip.API.Resources;
using Trip.API.Validators;

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

		[HttpGet("")]
		public async Task<ActionResult<IEnumerable<CountryResource>>> GetAll()
		{
			var countries = await _countryService.GetAll();
			var countriesResources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);

			return Ok(countriesResources);
		}

		[HttpGet("get-by-id")]
		public async Task<ActionResult<CountryResource>> GetById(int id)
		{
			var countries = await _countryService.GetById(id);

			return Ok(countries);
		}

		[HttpGet("get-by-code")]
		public async Task<ActionResult<CountryResource>> GetByCode(string code)
		{
			var countries = await _countryService.GetByCode(code);

			return Ok(countries);
		}

		[HttpPost]
		public async Task<ActionResult<CountryResource>> CreateCountry(CountryResource countryResource)
		{
			try
			{
				var validator = new CountryResourceValidator();
				var validationResult = await validator.ValidateAsync(countryResource);

				if (!validationResult.IsValid)
					return BadRequest(validationResult.Errors);

				var countryToCreate = _mapper.Map<CountryResource, Country>(countryResource);

				var newCountry = await _countryService.CreateCountry(countryToCreate);
				var newCountryResource = _mapper.Map<Country, CountryResource>(newCountry);
				return Ok(newCountryResource);
			}
			catch (BusinessException ex)
			{
				_logger.LogWarning(ex.HandledErrorMessage);
				return StatusCode(500, ex.HandledErrorMessage);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<CountryResource>> UpdateCountry(int id, CountryResource countryResource)
		{
			try
			{
				var validator = new CountryResourceValidator();
				var validationResult = await validator.ValidateAsync(countryResource);

				if (!validationResult.IsValid)
					return BadRequest(validationResult.Errors);

				var countryToBeUpdated = await _countryService.GetById(id);

				if (countryToBeUpdated == null)
					return NotFound();

				var country = _mapper.Map<CountryResource, Country>(countryResource);

				await _countryService.UpdateCountry(countryToBeUpdated, country);

				var updatedCountry = await _countryService.GetById(id);

				var updatedCountryResource = _mapper.Map<Country, CountryResource>(updatedCountry);

				return Ok(updatedCountryResource);
			}
			catch (BusinessException ex)
			{
				_logger.LogWarning(ex.Message);
				return StatusCode(500, ex.HandledErrorMessage);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _countryService.DeleteCountry(id);

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message);
				return StatusCode(500, ex.Message);
			}
		}
	}
}
