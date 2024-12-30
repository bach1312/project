using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class Report
    {
        public Report()
        {
            DisasterPoints = new HashSet<DisasterPoint>();
            FileAttachments = new HashSet<FileAttachment>();
        }

        public int ReportId { get; set; }
        public string ReportName { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }

        public virtual ICollection<DisasterPoint> DisasterPoints { get; set; }
        public virtual ICollection<FileAttachment> FileAttachments { get; set; }

        public Report Clone()
        {
            return (Report)this.MemberwiseClone();
        }
    }
}
