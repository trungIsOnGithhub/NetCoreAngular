using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos
{
    public class PlanCreateDto
    {
        [Required]
        public int AgencyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string HotelName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
    }
}