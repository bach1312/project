using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class UserLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime? ActionDate { get; set; }
        public string? Ipaddress { get; set; }
        public string? DeviceInfo { get; set; }
        public string? Description { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
