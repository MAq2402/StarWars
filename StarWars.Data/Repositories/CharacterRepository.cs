using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StarWars.Data.DbContexts;
using StarWars.Domain.Entities;

namespace StarWars.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly StarWarsDbContext _dbContext;

        public CharacterRepository(StarWarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Character character)
        {
            await _dbContext.AddAsync(character);
            await _dbContext.SaveChangesAsync();
        }
    }
}