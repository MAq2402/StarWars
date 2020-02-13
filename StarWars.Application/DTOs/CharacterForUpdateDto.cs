using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.DTOs
{
    public class CharacterForUpdateDto
    {
        public IEnumerable<string> Episodes { get; set; } = new List<string>();
        public string Planet { get; set; }
    }
}
