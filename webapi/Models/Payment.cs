using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Domain.Enums;

namespace webapi.Models
{
    public class Payment : BaseModel
    {
        public PaymentType Type { get; set; }
        public PaymentMethod Method { get; set; }
        public DateTime CreatedOn { get; set; }

        [MaxLength(255)]
        public string? Note { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }


        public string UserId { get; set; } = default;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }


        public int ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }


        public int? InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public Invoice? Invoice { get; set; }
    }
}