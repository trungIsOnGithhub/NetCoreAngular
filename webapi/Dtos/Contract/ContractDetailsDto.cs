using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Enums;

namespace webapi.Models
{
    public class ContractDetailsDto
    {
        public string Email { get; set; } = default;
        public string PhoneNumber { get; set; } = default;
        public string ContractNumber { get; set; } = default;

        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? CanceledOn {  get; set; }

        public string? RoomType { get; set; }
        public string? ServiceType { get; set; }
        public string? TransportationType { get; set; }
        public string? Insurance {  get; set; }
        public string? Note { get; set; }
        public string? Footer { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public double TotalPrice { get; set; }

        public double AmmountPaid { get; set; }
        public double AmountPaidToVendor { get; set; }

        public bool IsPaid { get; set; }

        public UserDetailsDto User { get; set; }
        public PlanListDto Plan { get; set; }
    }
}