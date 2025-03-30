
using onpmysql.Models;
using onpmysql.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace onpmysql.Repositories;

public class  TwitterRepository: ITwitterRepository
{
    private readonly CsvDbContext _context;

    public TwitterRepository(CsvDbContext context)
{        _context = context;
}
   public async Task<IEnumerable<Twitter>> GetAllAsync()
    {
        return await _context.twitters.ToListAsync<Twitter>();
    }
        public async Task<Twitter?> GetByIdAsync(long id)
    {
        return await _context.twitters.FindAsync(id);
    }

    public async Task AddAsync(Twitter entity)
    {
        await _context.twitters.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Twitter entity)
    {
        _context.twitters.Update(entity); 
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.twitters.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Twitter>> GetByCountryAsync(string country)
    {
        return await _context.twitters
            .Where(c => c.Country == country)
            .ToListAsync();
    }
}

