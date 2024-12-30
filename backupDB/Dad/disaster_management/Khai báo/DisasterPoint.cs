using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class DisasterPoint
    {
        public int DisasterId { get; set; }
        public string DisasterType { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Description { get; set; }
        public DateTime OccurredTime { get; set; } = DateTime.Now;
        public string? Severity { get; set; }
        public int? ReportId { get; set; }

        public virtual Report? Report { get; set; }

        public DisasterPoint Clone()
        {
            return (DisasterPoint)MemberwiseClone();
        }
    }
}
