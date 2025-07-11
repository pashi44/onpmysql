using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZomatoDb.Models
{
    public class ZomatoModelOne
    {
        [Key]
        public long RestaurantId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Restaurant Name")]
        public string? RestaurantName { get; set; }

        [Display(Name = "Country Code")]
        public long? CountryCode { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [MaxLength(255)]
        public string? Locality { get; set; }

        [DataType(DataType.MultilineText)]
        public string? LocalityVerbose { get; set; }

        [Column(TypeName = "double")]
        public double? Longitude { get; set; }

        [Column(TypeName = "double")]
        public double? Latitude { get; set; }

        [MaxLength(255)]
        public string? Cuisines { get; set; }

        [Display(Name = "Average Cost for Two")]
        public long? AverageCostForTwo { get; set; }

        [MaxLength(50)]
        public string? Currency { get; set; }

        [MaxLength(10)]
        [Display(Name = "Has Table Booking")]
        public string? HasTableBooking { get; set; }

        [MaxLength(10)]
        [Display(Name = "Has Online Delivery")]
        public string? HasOnlineDelivery { get; set; }

        [MaxLength(10)]
        [Display(Name = "Is Delivering Now")]
        public string? IsDeliveringNow { get; set; }

        [MaxLength(10)]
        public string? SwitchToOrderMenu { get; set; }

        [Range(1, 5)]
        public long? PriceRange { get; set; }

        [Column(TypeName = "float")]
        [Range(0, 5)]
        public float? AggregateRating { get; set; }

        [MaxLength(50)]
        public string? RatingColor { get; set; }

        [MaxLength(50)]
        public string? RatingText { get; set; }

        public long? Votes { get; set; }

        // (Optional) Add reference to user if you want to track who created this record
        // public string? UserId { get; set; } 
        // [ForeignKey("UserId")]
        // public ApplicationUser? User { get; set; }
    }
}