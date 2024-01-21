using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; } = default;
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; } = default;

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = default;

        public string? LastToken { get; set; }

        public DateTime? RegisterDate { get; set; }

        public DateTime? TokenExpireDate { get; set; }


        public int OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }

        public List<Contract> Contracts { get; set; } = new();

        public List<Invoice> Invoices { get; set; } = new();
    }
}