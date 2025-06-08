using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using onpmysql.Models;
using Pomelo.EntityFrameworkCore.MySql;


namespace onpmysql.DbData
{
    public class CsvDbContext : DbContext
    {

        private readonly DbContextOptions<CsvDbContext> _options;
        public CsvDbContext(DbContextOptions<CsvDbContext> options) : base(options)
        {

            _options = options;
        }


        public DbSet<Twitter> twitters { get { return Set<Twitter>(); } }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Twitter>(entity =>
            {
                entity.ToTable("twitter");


                entity.HasKey(c0 => c0.C0);
                entity.Property<string?>(geo => geo.Geo);
                entity.Property<string?>(text => text.Text);
                entity.Property<string?>(user => user.User);

                entity.Property<string?>(location => location.Location);
                entity.Property<string?>(entities => entities.Entities);
                entity.Property<string?>(sentiment => sentiment.Sentiment);
                entity.Property<string?>(country => country.Country);

            });

        }
    }
}
