using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Property : Base
    {
        public int SellRent { get; set; }
        public string Name { get; set; }
        
        public int Price { get; set; }
        public int BHK { get; set; }
        public int BuiltArea { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public bool ReadyToMove { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }

        public int FloorNo { get; set; }

        public int TotalFloors { get; set; }

        public string MainEntrance { get; set; }

        public int Security { get; set; }

        public bool Gated { get; set; }

        public int Maintenance { get; set; }

        public DateTime EstPossessionOn { get; set; }

        public string Description { get; set; }

        public DateTime PostedOn { get; set; } = DateTime.Now;
        
        [ForeignKey("User")]
        public int PostedBy { get; set; }
        public User User { get; set; }       
    }
}