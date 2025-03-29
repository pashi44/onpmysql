using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using onpmysql.Models;
using  Pomelo.EntityFrameworkCore.MySql;


namespace  onpmysql.DbData
{
    public class CsvDbContext : DbContext
    {

        private readonly DbContextOptions<CsvDbContext> _options;
        public CsvDbContext(DbContextOptions<CsvDbContext> options):base(options)
        {

            _options  = options;
        }

        public DbSet<Corona>     coronas { get{return Set<Corona>();}}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




        }
    }
}
