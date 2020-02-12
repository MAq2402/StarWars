using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StarWars.Application.DTOs;

namespace StarWars.Application.Services
{
    public class InMemoryCharacterService : ICharacterService
    {
        public async Task<IEnumerable<CharacterDto>> GetCharactersAsync()
        {
            var episodes = new List<string>()
            {
                "NEWHOPE",
                "EMPIRE",
                "JEDI"
            };

            var characters = new List<CharacterDto>()
            {
                new CharacterDto()
                {
                    Name = "Luke Skywalker",
                    Episodes = episodes,
                    Friends = new List<string>() {"Lela Organa"}
                },
                new CharacterDto()
                {
                    Name = "Lela Organa",
                    Episodes = episodes,
                    Planet = "Alderaan",
                    Friends = new List<string>() {"Luke Skywalker"}
                },
            };

            return await Task.FromResult(characters);
        }
    }
}