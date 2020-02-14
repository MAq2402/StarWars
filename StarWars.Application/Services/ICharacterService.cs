using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StarWars.Application.DTOs;

namespace StarWars.Application.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetCharactersAsync();
        IEnumerable<CharacterDto> GetCharacters(int pageNumber, int pageSize);
        Task<CharacterDto> GetCharacterAsync(Guid id);
        Task<bool> CheckIfCharacterExistsAsync(Guid id);
        Task AddCharacterAsync(CharacterForCreationDto dto);
        Task AddFriendForCharacterAsync(Guid firstCharacterId, Guid secondCharacterId);
        Task UpdateCharacterAsync(CharacterForUpdateDto dto, Guid id);
        Task DeleteCharacterAsync(Guid id);
    }
}