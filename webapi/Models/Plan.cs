using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Plan : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string HotelName { get; set; } = default;

        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = default;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = default;

        [Required]
        public int AgencyId { get; set; }

        [ForeignKey("AgencyId")]
        public Agency Agency { get; set; }

        [InverseProperty("Plan")]
        public List<AvailableDate> AvailableDates { get; set; } = new();
    }
}