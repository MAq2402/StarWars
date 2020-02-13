using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWars.Domain.Entities;

namespace StarWars.Data.Repositories
{
    public interface ICharacterRepository
    {
        IQueryable<Character> Get(int pageNumber, int pageSize);
        Task<IEnumerable<Character>> GetAllAsync();
        Task<Character> GetSingleAsync(Guid id);
        Task<bool> CheckIfCharacterExistsAsync(Guid id);
        Task AddAsync(Character character);
        Task DeleteCharacterAsync(Guid id);
        Task SaveChangesAsync();
    }
}
