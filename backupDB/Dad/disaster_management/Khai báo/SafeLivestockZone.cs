using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class SafeLivestockZone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; } = null!;
        public string? Address { get; set; }

        public SafeLivestockZone Clone() => (SafeLivestockZone)this.MemberwiseClone();
    }
}
