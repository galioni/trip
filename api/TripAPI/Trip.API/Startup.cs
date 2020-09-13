using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trip.API.Core.Mapping;
using Trip.API.Core.Repositories;
using Trip.API.Infrastructure;
using Trip.API.Infrastructure.Context;

namespace Trip.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TripDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Default"));
				options.UseLazyLoadingProxies(true);
			});

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<ICountryRepository, CountryRepository>();

			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new DataProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
