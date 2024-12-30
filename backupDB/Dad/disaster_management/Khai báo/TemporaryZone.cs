using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class TemporaryZone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; } = null!;
        public string? Address { get; set; }
        public int? Capacity { get; set; }

        internal TemporaryZone Clone()
        {
            return (TemporaryZone)this.MemberwiseClone();  
        }
    }
}
