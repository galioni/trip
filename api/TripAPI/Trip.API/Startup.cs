using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
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
			}, ServiceLifetime.Transient);

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddTransient<ICountryService, CountryService>();

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "Trip", Version = "v1" });
			});

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

			app.UseExceptionHandler(a => a.Run(async context =>
			{
				var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
				var exception = exceptionHandlerPathFeature.Error;

				var result = JsonConvert.SerializeObject(new { error = exception.Message });
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(result);
			}));

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip V1");
			});
		}
	}
}
