using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos
{
    public class UserRefreshDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}