using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;

namespace StarWars.Data.DbContexts
{
    public class StarWarsDbContext : DbContext
    {
        public StarWarsDbContext(DbContextOptions<StarWarsDbContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterFriendship> CharacterFriendships { get; set; }
    }
}