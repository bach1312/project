using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class LivestockFarm
    {
        public LivestockFarm()
        {
            Certificates = new HashSet<Certificate>();
            LivestockFarmConditions = new HashSet<LivestockFarmCondition>();
            LivestockStatistics = new HashSet<LivestockStatistic>();
        }

        public int FarmId { get; set; }
        public string FarmName { get; set; } = null!;
        public string? Address { get; set; }
        public string? OwnerName { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<LivestockFarmCondition> LivestockFarmConditions { get; set; }
        public virtual ICollection<LivestockStatistic> LivestockStatistics { get; set; }

        public LivestockFarm Clone()
        {
            return (LivestockFarm)this.MemberwiseClone();   
        }
    }
}
