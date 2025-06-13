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
// SELECT[t].[C0], [t].[Country], [t].[Entities], [t].[Geo], [t].[Location], [t].[Sentiment], [t].[Text], [t].[User]
      entity.ToTable("twitter");
      entity.HasKey(c0 => c0.C0);
      entity.Property<string?>(geo => geo.Geo).HasColumnName("geo");
      entity.Property<string?>(text => text.Text).HasColumnName("text");
      entity.Property<string?>(user => user.User).HasColumnName("user");
      entity.Property<string?>(location => location.Location).HasColumnName("location");
      entity.Property<string?>(entities => entities.Entities).HasColumnName("entities");
      entity.Property<string?>(sentiment => sentiment.Sentiment).HasColumnName("sentiment");
      entity.Property<string?>(country => country.Country).HasColumnName("country");
                  });


                  // restaurant_id        | int          | YES  |     | NULL    |       |
                  // | restaurant_name      | varchar(255) | YES  |     | NULL    |       |
                  // | country_code         | int          | YES  |     | NULL    |       |
                  // | city                 | varchar(100) | YES  |     | NULL    |       |
                  // | address              | text         | YES  |     | NULL    |       |
                  // | locality             | varchar(255) | YES  |     | NULL    |       |
                  // | locality_verbose     | text         | YES  |     | NULL    |       |
                  // | longitude            | double       | YES  |     | NULL    |       |
                  // | latitude             | double       | YES  |     | NULL    |       |
                  // | cuisines             | varchar(255) | YES  |     | NULL    |       |
                  // | average_cost_for_two | int          | YES  |     | NULL    |       |
                  // | currency             | varchar(50)  | YES  |     | NULL    |       |
                  // | has_table_booking    | varchar(10)  | YES  |     | NULL    |       |
                  // | has_online_delivery  | varchar(10)  | YES  |     | NULL    |       |
                  // | is_delivering_now    | varchar(10)  | YES  |     | NULL    |       |
                  // | switch_to_order_menu | varchar(10)  | YES  |     | NULL    |       |
                  // | price_range          | int          | YES  |     | NULL    |       |
                  // | aggregate_rating     | float        | YES  |     | NULL    |       |
                  // | rating_color         | varchar(50)  | YES  |     | NULL    |       |
                  // | rating_text          | varchar(50)  | YES  |     | NULL    |       |
                  // | votes     

                  //adds entity to th  db if nott a part of db

      modelBuilder.Entity<ZomatoModelOne>(entity =>
{
       entity.ToTable("zomatorestaurants");
       entity.HasKey(e => e.RestaurantId);
       entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
       entity.Property(e => e.RestaurantName).HasColumnName("restaurant_name");
 entity.Property(e => e.CountryCode).HasColumnName("country_code");
entity.Property(e => e.City)
.HasMaxLength(100).HasColumnName("City");
                               entity.Property(e => e.Address)
                     .HasColumnType("nvarchar(max)").HasColumnName("address");
                               entity.Property(e => e.Locality)
                     .HasMaxLength(255).HasColumnName("locality");
                               entity.Property(e => e.LocalityVerbose)
                     .HasColumnType("nvarchar(max)").HasColumnName("locality_verbose");
                               entity.Property(e => e.Longitude)
                             .HasColumnName("longitude");
                               entity.Property(e => e.Latitude).HasColumnName("latitude");
                               entity.Property(e => e.Cuisines).HasColumnName("cuisines");
                               entity.Property(e => e.AverageCostForTwo).HasColumnName("average_cost_for_two");
                               entity.Property(e => e.Currency).HasColumnName("currency");
                               entity.Property(e => e.HasTableBooking).HasColumnName("has_table_booking");
                               entity.Property(e => e.HasOnlineDelivery).HasColumnName("has_online_delivery");
                               entity.Property(e => e.IsDeliveringNow).HasColumnName("is_delivering_now");
                               entity.Property(e => e.SwitchToOrderMenu).HasColumnName("switch_to_order_menu");
                               entity.Property(e => e.PriceRange).HasColumnName("price_range");
                               entity.Property(e => e.AggregateRating).HasColumnName("aggregate_rating");
                               entity.Property(e => e.RatingColor).HasColumnName("rating_color");
                               entity.Property(e => e.RatingText).HasColumnName("rating_text");

                               entity.Property(e => e.Votes).HasColumnName("votes");
                         });
            }
      }
}
