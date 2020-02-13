using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.DTOs
{
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Episodes { get; set; } = new List<string>();
        public string Planet { get; set; }
        public IEnumerable<string> Friends { get; set; } = new List<string>();
    }
}