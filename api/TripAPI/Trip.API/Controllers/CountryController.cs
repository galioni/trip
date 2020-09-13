using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Trip.API.Infrastructure;
using Trip.API.Infrastructure.Entities;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Controllers
{
	[ApiController]
	[Route("country")]
	public class CountryController : ControllerBase
	{
		private readonly ILogger<CountryController> _logger;
		private IUnitOfWork _unitOfWork = null;
		private ICountryRepository _countryRepository = null;

		public CountryController(ILogger<CountryController> logger, IUnitOfWork unitOfWork, ICountryRepository countryRepository)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
			_countryRepository = countryRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var countries = await _unitOfWork.GetRepository<CountryEntity>().GetAsync();

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
