using StarWars.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Net;
using StarWars.Data.DbContexts;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace StarWars.Web.Tests.Controllers
{
    public class CharacterControllerTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly InMemoryWebApplicationFactory<Startup> _factory;

        public CharacterControllerTests(InMemoryWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateCharacterAsync_ShouldWork()
        {
            var url = "/api/characters";
            var body = new CharacterForCreationDto() { Name = "Luke Skywalker", Episodes = new string[] { "JEDI", "NEWHOPE", "EMPIRE" } };
            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StarWarsDbContext>();

            var httpResponse = await _client.PostAsync(url, 
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();

            var actualStatusCode = httpResponse.StatusCode;
            var expectedStatusCode = HttpStatusCode.Created;

            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.True(dbContext.Characters.Any(c => c.Name == "Luke Skywalker"));
        }
    }
}
