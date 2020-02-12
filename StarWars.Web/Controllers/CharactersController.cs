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
        private ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharactersAsync()
        {
            return Ok(await _characterService.GetCharactersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacterAsync([FromBody] CharacterForCreationDto dto)
        {
            await _characterService.AddCharacterAsync(dto);

            return Created(string.Empty, null);
        }
    }
}