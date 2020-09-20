using AutoMapper;
using Trip.API.Core.Models;
using Trip.API.Resources;

namespace Trip.API.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Domain to Resource
			CreateMap<Country, CountryResource>();

			// Resource to Domain
			CreateMap<CountryResource, Country>();
		}
	}
}
