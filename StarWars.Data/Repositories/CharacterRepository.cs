using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Character> Get(int pageNumber, int pageSize)
        {
            return _dbContext.Characters.Include(c => c.FriendshipsWhereIsFirst)
                .ThenInclude(f => f.Second)
                .Include(c => c.FriendshipsWhereIsSecond)
                .ThenInclude(f => f.First)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _dbContext.Characters.Include(c => c.FriendshipsWhereIsFirst)
                .ThenInclude(f => f.Second)
                .Include(c => c.FriendshipsWhereIsSecond)
                .ThenInclude(f => f.First)
                .ToListAsync();
        }

        public async Task<Character> GetSingleAsync(Guid id)
        {
            return await _dbContext.Characters.Include(c => c.FriendshipsWhereIsFirst)
                .ThenInclude(f => f.Second)
                .Include(c => c.FriendshipsWhereIsSecond)
                .ThenInclude(f => f.First)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CheckIfCharacterExistsAsync(Guid id)
        {
            return await _dbContext.Characters.AnyAsync(c => c.Id == id);
        }

        public async Task AddAsync(Character character)
        {
            await _dbContext.AddAsync(character);
        }

        public async Task DeleteCharacterAsync(Guid id)
        {
            var character = await GetSingleAsync(id);
            _dbContext.CharacterFriendships.RemoveRange(character.FriendshipsWhereIsFirst);
            _dbContext.CharacterFriendships.RemoveRange(character.FriendshipsWhereIsSecond);
            _dbContext.Characters.Remove(character);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}