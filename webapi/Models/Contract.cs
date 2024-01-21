using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Enums;

namespace webapi.Models
{
    public class Contract : BaseModel
    {
        [Required]
        [MaxLength(60)]
        public string Email { get; set; } = default;

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = default;

        [Required]
        [MaxLength(30)]
        public string ContractNumber { get; set; } = default;

        [Required]
        [MaxLength(30)]
        public string ContractLocation { get; set; } = default;

        [Required]
        [MaxLength(150)]
        public string PrimaryPassenger { get; set; } = default;

        [MaxLength(127)]
        public string? Insurance {  get; set; }

        [MaxLength(255)]
        public string? Note { get; set; }

        public string? Footer { get; set; }

        [Required]
        public DateTime ContractDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime? DepartureTime { get; set; }

        public DateTime? CanceledOn {  get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [MaxLength(30)]
        public string? RoomType { get; set; }

        [MaxLength(40)]
        public string? ServiceType { get; set; }

        [MaxLength(20)]
        public string? TransportationType { get; set; }

        [Required]
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double AmmountPaid { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double AmountPaidToVendor { get; set; }


        public bool IsPaid { get; set; }
        public bool IsArchived { get; set; }


        [Required]
        public int OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }


        public string UserId { get; set; } = default;

        [ForeignKey(nameof(UserId))]
        public TravelUser User { get; set; }


        [Required]
        public int PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        [InverseProperty("Contract")]
        public List<Passenger> Passengers { get; set; } = new();

        // [InverseProperty("Contract")]
        // public List<ContractEmailEvent> EmailEvents { get; set; } = new();
    }
}