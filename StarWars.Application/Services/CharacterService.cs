using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StarWars.Application.DTOs;
using StarWars.Data.Repositories;
using StarWars.Domain.Entities;

namespace StarWars.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CharacterDto>> GetCharactersAsync()
        {
            var charactersFromRepo = await _characterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CharacterDto>>(charactersFromRepo);
        }

        public async Task<CharacterDto> GetCharacterAsync(Guid id)
        {
            var characterFromRepo = await _characterRepository.GetSingleAsync(id);
            return _mapper.Map<CharacterDto>(characterFromRepo);
        }

        public async Task<bool> CharacterExistsAsync(Guid id)
        {
            return await _characterRepository.CharacterExistsAsync(id);
        }

        public async Task AddCharacterAsync(CharacterForCreationDto dto)
        {
            var character = new Character(dto.Name, dto.Planet, dto.Episodes);

            await _characterRepository.AddAsync(character);

            await _characterRepository.SaveChangesAsync();
        }

        public async Task AddFriendForCharacterAsync(Guid firstCharacterId, Guid secondCharacterId)
        {
            var firstCharacter = await _characterRepository.GetSingleAsync(firstCharacterId);
            var secondCharacter = await _characterRepository.GetSingleAsync(secondCharacterId);

            firstCharacter.MakeFriendship(secondCharacter);

            await _characterRepository.SaveChangesAsync();
        }

        public async Task UpdateCharacterAsync(CharacterForUpdateDto dto, Guid id)
        {
            var character = await _characterRepository.GetSingleAsync(id);
            character.Update(dto.Planet, dto.Episodes);

            await _characterRepository.SaveChangesAsync();
        }

        public async Task DeleteCharacterAsync(Guid id)
        {
            await _characterRepository.DeleteCharacterAsync(id);

            await _characterRepository.SaveChangesAsync();
        }
    }
}