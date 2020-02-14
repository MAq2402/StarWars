using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using StarWars.Data.DbContexts;
using System.Linq;

namespace StarWars.Web.Tests
{
    public class InMemoryWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveDbContext(services);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<StarWarsDbContext>(options =>
                {
                    options.UseInMemoryDatabase("StarWarsInMemoryDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var builtServiceProvider = services.BuildServiceProvider();

                using var scope = builtServiceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<StarWarsDbContext>();

                dbContext.Database.EnsureCreated();
            });
        }

        private void RemoveDbContext(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<StarWarsDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
}
