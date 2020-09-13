using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trip.API.Core;
using Trip.API.Core.Services.Implementations;
using Trip.API.Core.Services.Interfaces;
using Trip.API.Data;
using Trip.API.Data.Context;

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
			services.AddControllers();

			services.AddDbContext<TripDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Trip.API.Data"));
				options.UseLazyLoadingProxies(true);
			});

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddTransient<ICountryService, CountryService>();

			services.AddAutoMapper(typeof(Startup));
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
