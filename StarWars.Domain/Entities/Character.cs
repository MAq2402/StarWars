﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace StarWars.Domain.Entities
{
    public class Character
    {
        private List<string> _episodes;
        private readonly List<CharacterFriendship> friendshipsWhereIsFirst = new List<CharacterFriendship>();
        private readonly List<CharacterFriendship> friendshipsWhereIsSecond = new List<CharacterFriendship>();

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
        public IEnumerable<CharacterFriendship> FriendshipsWhereIsFirst => friendshipsWhereIsFirst;
        public IEnumerable<CharacterFriendship> FriendshipsWhereIsSecond => friendshipsWhereIsSecond;
        public IEnumerable<Character> Friends => friendshipsWhereIsFirst.Select(f => f.Second)
            .Concat(friendshipsWhereIsSecond.Select(f => f.First));

        public void MakeFriendship(Character otherCharacter)
        {
            var friendship = new CharacterFriendship(this, otherCharacter);
            friendshipsWhereIsFirst.Add(friendship);
        }

        public void Update(string planet, IEnumerable<string> episodes)
        {
            Planet = planet;
            _episodes = episodes.ToList();
        }
    }
}