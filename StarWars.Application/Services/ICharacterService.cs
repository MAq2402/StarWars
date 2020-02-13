﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StarWars.Application.DTOs;

namespace StarWars.Application.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetCharactersAsync();
        Task<CharacterDto> GetCharacterAsync(Guid id);
        Task<bool> CharacterExistsAsync(Guid id);
        Task AddCharacterAsync(CharacterForCreationDto dto);
        Task AddFriendForCharacterAsync(Guid firstCharacterId, Guid secondCharacterId);
    }
}