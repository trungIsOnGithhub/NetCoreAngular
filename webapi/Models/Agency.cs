using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Agency : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default;

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = default;

        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; } = default;

        [MaxLength(100)]
        public string? AccountNumber { get; set; }


        [Required]
        public int OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }


        [InverseProperty("Agency")]
        public List<Plan> Plans { get; set; } = new();
    }
}