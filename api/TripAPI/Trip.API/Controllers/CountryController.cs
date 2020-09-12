using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Trip.API.Core.Interfaces.Gateways.Repositories;

namespace Trip.API.Controllers
{
	[ApiController]
	[Route("country")]
	public class CountryController : ControllerBase
	{
		private readonly ILogger<CountryController> _logger;

		private readonly ICountryRepository _countryRepository;

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
	}
}
