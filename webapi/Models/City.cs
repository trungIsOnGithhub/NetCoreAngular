using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class City : BaseEntity
    {
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Required]
        [Column(Order = 2)]
        public string Country { get; set; }

        public City(string name, string country)
        {
            this.Name = name;
            this.Country = country;
        }
    }
}