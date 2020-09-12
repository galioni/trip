using AutoMapper;
using Trip.API.Core.Domain.Entities;
using Trip.API.Infrastructure.Entities;

namespace Trip.API.Infrastructure.Mapping
{
	public class Profiles : Profile
	{
		public Profiles()
		{
			//CreateMap<Country, CountryEntity>().ConstructUsing(c => new CountryEntity { Code = c.Code, Created = c.Created, Id = c.Id, IsActive = c.IsActive, Modified = c.Modified, Name = c.Name });
			//CreateMap<CountryEntity, Country>().ConstructUsing(c => new Country(c.Id, c.Name, c.Code, c.IsActive, c.Created, c.Modified));
		}
	}
}
