﻿using AutoMapper;
using Trip.API.Core.Domain;
using Trip.API.Infrastructure.Entities;

namespace Trip.API.Core.Mapping
{
	public class DataProfile : Profile
	{
		public DataProfile()
		{
			CreateMap<Country, CountryEntity>().ConstructUsing(x => new CountryEntity { Code = x.Code, Created = x.Created, Id = x.Id, IsActive = x.IsActive, Modified = x.Modified, Name = x.Name });
			CreateMap<CountryEntity, Country>().ConstructUsing(x => new Country { Code = x.Code, Created = x.Created, Id = x.Id, IsActive = x.IsActive, Modified = x.Modified, Name = x.Name });
		}
	}
}
