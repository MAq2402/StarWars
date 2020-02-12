using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Entities
{
    public class CharacterFriendship
    {
        private CharacterFriendship()
        {

        }

        public CharacterFriendship(Character first, Character second)
        {
            Id = Guid.NewGuid();
            First = first;
            Second = second;
        }

        public Guid Id { get; private set; }
        public Character First { get; private set; }
        public Character Second{ get; private set; }
    }
}
