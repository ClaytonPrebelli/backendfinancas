using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using financasPrebelli.Data;


namespace financasPrebelli
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

			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
					   
					   
			}));
			services.AddControllers();
			

			string stringConexao = Configuration.GetConnectionString("conexaoMySQL");
			services.AddDbContext<DataContext>(opt => opt.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao)));
			services.AddSwaggerGen(config =>
			{
				config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "financasPrebelli",
					Version = "v1"
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "financasPrebelli v1");
				c.RoutePrefix = string.Empty;

			});
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseCors("MyPolicy");

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
