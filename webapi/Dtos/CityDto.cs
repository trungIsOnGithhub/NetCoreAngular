using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage = "Name is mandatory field")]
        [StringLength(36, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]        
        public string Name { get; set; }
        
        [Required]
        [StringLength(36, MinimumLength = 2)]
        public string Country { get; set; }
    }
}