using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class User : Base
    {
        [Required]
        [StringLength(36, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        public byte[] Password { get; set; }

        public byte[] HashKey { get; set; }
    }
}