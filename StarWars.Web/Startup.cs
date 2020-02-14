using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StarWars.Application.Mappings.Profiles;
using StarWars.Application.Services;
using StarWars.Data.DbContexts;
using StarWars.Data.Repositories;

namespace StarWars.Web
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
            services.AddMvc().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });

            services.AddDbContext<StarWarsDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddAutoMapper(typeof(CharacterProfile));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarWars", Version = "v1" }));

            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarWars");
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}