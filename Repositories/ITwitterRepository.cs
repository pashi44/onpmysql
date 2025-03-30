using onpmysql.Models;
namespace  onpmysql.Repositories;

public interface  ITwitterRepository
{
    Task<IEnumerable<Twitter>> GetAllAsync();
    Task<Twitter?> GetByIdAsync(long id);
    Task AddAsync(Twitter entity);
    Task UpdateAsync(Twitter entity);
    Task DeleteAsync(  long id);
    Task<IEnumerable<Twitter>> GetByCountryAsync(string country);
}
