using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class VeterinaryBranch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public VeterinaryBranch Clone()
        {
           return (VeterinaryBranch)this.MemberwiseClone();
        }
    }
}
