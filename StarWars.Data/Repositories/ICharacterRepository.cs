using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StarWars.Domain.Entities;

namespace StarWars.Data.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character> GetSingleAsync(Guid id);
        Task AddAsync(Character character);
        Task SaveChangesAsync();
    }
}
