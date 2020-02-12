using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWars.Domain.Entities
{
    public class Character
    {
        private readonly List<string> _episodes;
        private readonly List<CharacterFriendship> _friendshipsWhereIsFirst = new List<CharacterFriendship>();
        private readonly List<CharacterFriendship> _friendshipsWhereIsSecond = new List<CharacterFriendship>();

        private Character()
        {

        }

        public Character(string name, string planet, IEnumerable<string> episodes)
        {
            Id = Guid.NewGuid();
            Name = name;
            Planet = planet;
            _episodes = episodes.ToList();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Planet { get; private set; }
        public IEnumerable<string> Episodes => _episodes;
        public IEnumerable<CharacterFriendship> FriendshipsWhereIsFirst => _friendshipsWhereIsFirst;
        public IEnumerable<CharacterFriendship> FriendshipsWhereIsSecond => _friendshipsWhereIsSecond;
        public IEnumerable<CharacterFriendship> Friendships =>
            _friendshipsWhereIsFirst.Concat(_friendshipsWhereIsSecond);
    }
}