using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class Certificate
    {
        public int CertificateId { get; set; }
        public int? FarmId { get; set; }
        public DateTime? IssueDate { get; set; } = DateTime.Now;
        public DateTime? ExpiryDate { get; set; }  = DateTime.Now;
        public string? CertificateName { get; set; }
        public virtual LivestockFarm? Farm { get; set; }

        public Certificate Clone()
        {
            return (Certificate)this.MemberwiseClone();
        }
    }
}
