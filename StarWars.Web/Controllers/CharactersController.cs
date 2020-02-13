using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.DTOs;
using StarWars.Application.Services;

namespace StarWars.Web.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharactersAsync()
        {
            return Ok(await _characterService.GetCharactersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterAsync(string id)
        {
            if (!await _characterService.CharacterExistsAsync(new Guid(id)))
            {
                return NotFound("Character with given id does not exist");
            }

            return Ok(await _characterService.GetCharacterAsync(new Guid(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacterAsync([FromBody] CharacterForCreationDto dto)
        {
            await _characterService.AddCharacterAsync(dto);

            return Created(string.Empty, null);
        }

        [HttpPost("{id}/friendships")]
        public async Task<IActionResult> CreateFriendship([FromBody] CharacterFriendshipForCreationDto dto, string id)
        {
            if (!await _characterService.CharacterExistsAsync(new Guid(id)) ||
                !await _characterService.CharacterExistsAsync(new Guid(dto.CharacterId)))
            {
                return BadRequest("One or both of given characters do not exist");
            }

            await _characterService.AddFriendForCharacterAsync(new Guid(id), new Guid(dto.CharacterId));

            return Created(string.Empty, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacterAsync([FromBody] CharacterForUpdateDto dto, string id)
        {
            if (!await _characterService.CharacterExistsAsync(new Guid(id)))
            {
                return NotFound("Character with given id does not exist");
            }

            await _characterService.UpdateCharacterAsync(dto, new Guid(id));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterAsync(string id)
        {
            if (!await _characterService.CharacterExistsAsync(new Guid(id)))
            {
                return NotFound("Character with given id does not exist");
            }

            await _characterService.DeleteCharacterAsync(new Guid(id));

            return NoContent();
        }
    }
}