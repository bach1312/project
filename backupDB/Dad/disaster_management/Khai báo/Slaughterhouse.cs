using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class Slaughterhouse
    {
        public int SlaughterhouseId { get; set; }
        public string SlaughterhouseName { get; set; } = null!;
        public string? Address { get; set; }
        public int? Capacity { get; set; }

        public Slaughterhouse Clone()
        {
            return (Slaughterhouse)this.MemberwiseClone();
        }
    }
}
