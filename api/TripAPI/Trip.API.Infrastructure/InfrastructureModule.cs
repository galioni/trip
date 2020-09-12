using Autofac;
using Trip.API.Core.Interfaces.Gateways.Repositories;
using Trip.API.Infrastructure.Repositories;

namespace Trip.API.Infrastructure
{
	public class InfrastructureModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerLifetimeScope();
		}
	}
}
