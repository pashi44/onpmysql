using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using onpmysql.Models;
using ZomatoDb.Models;
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

//dbSet define and entity of table
        public DbSet<Twitter> twitters { get { return Set<Twitter>(); } }

        // 
        // public DbSet<ZomatoModelOne> restaruntChains =
        // {
        // new ZomatoModelOne{ RestaurantId =1; }
        // }
        // 


        public DbSet<ZomatoModelOne> ZomatotableEntity => Set<ZomatoModelOne>();




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


            modelBuilder.Entity<ZomatoModelOne>(entity =>
                   {
                       entity.HasKey(e => e.RestaurantId);

                       entity.Property(e => e.RestaurantName)
                             .HasMaxLength(255)
                             .HasColumnName("RestaurantName");

                       entity.Property(e => e.CountryCode);

                       entity.Property(e => e.City)
                             .HasMaxLength(100);

                       entity.Property(e => e.Address)
                             .HasColumnType("nvarchar(max)");

                       entity.Property(e => e.Locality)
                             .HasMaxLength(255);

                       entity.Property(e => e.LocalityVerbose)
                             .HasColumnType("nvarchar(max)");

                       entity.Property(e => e.Longitude)
                             .HasColumnType("double");

                       entity.Property(e => e.Latitude)
                             .HasColumnType("double");

                       entity.Property(e => e.Cuisines)
                             .HasMaxLength(255);

                       entity.Property(e => e.AverageCostForTwo);

                       entity.Property(e => e.Currency)
                             .HasMaxLength(50);

                       entity.Property(e => e.HasTableBooking)
                             .HasMaxLength(10);

                       entity.Property(e => e.HasOnlineDelivery)
                             .HasMaxLength(10);

                       entity.Property(e => e.IsDeliveringNow)
                             .HasMaxLength(10);

                       entity.Property(e => e.SwitchToOrderMenu)
                             .HasMaxLength(10);

                       entity.Property(e => e.PriceRange)
                             .HasColumnType("int");

                       entity.Property(e => e.AggregateRating)
                             .HasColumnType("float");

                       entity.Property(e => e.RatingColor)
                             .HasMaxLength(50);

                       entity.Property(e => e.RatingText)
                             .HasMaxLength(50);

                       entity.Property(e => e.Votes);

                   });
        }
    }
}
