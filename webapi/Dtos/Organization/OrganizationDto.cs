using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos
{
    public class OrganizationDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = default;

        [Required]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; } = default;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = default;

        [MaxLength(60)]
        public string? Address { get; set; }

        [MaxLength(30)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? Website { get; set; }

        [MaxLength(50)]
        public string? Location { get; set; }

        public string? DefaultFooter { get; set; }

        public string? InvoiceNote { get; set; }

        public int TaxPercentage { get; set; }
    }
}