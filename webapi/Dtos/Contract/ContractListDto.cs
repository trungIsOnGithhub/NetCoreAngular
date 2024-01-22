using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos
{
    public class ContractListDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string ContractNumber { get; set; }
        public string HolderName { get; set; }

        [Required]
        [MaxLength(60)]
        public string Email { get; set; }

        public string HotelName { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime ContractDate { get; set; }
    
        [Required]
        [Range(0, double.MaxValue)]
        public double AmountPaid { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }
    }
}