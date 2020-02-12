using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StarWars.Application.DTOs;
using StarWars.Data.Repositories;
using StarWars.Domain.Entities;

namespace StarWars.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<IEnumerable<CharacterDto>> GetCharactersAsync()
        {
            return await Task.FromResult(new List<CharacterDto>());
        }

        public async Task AddCharacterAsync(CharacterForCreationDto dto)
        {
            var character = new Character(dto.Name, dto.Planet, dto.Episodes);

            await _characterRepository.AddAsync(character);
        }
    }
}