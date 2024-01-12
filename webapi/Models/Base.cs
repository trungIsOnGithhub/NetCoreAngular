using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Base
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
    }
}