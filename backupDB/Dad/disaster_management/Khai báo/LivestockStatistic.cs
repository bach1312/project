using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class LivestockStatistic
    {
        public int StatisticId { get; set; }
        public int? FarmId { get; set; }
        public DateTime? StatisticDate { get; set; } = DateTime.Now;
        public string? AnimalType { get; set; }
        public int? AnimalCount { get; set; }

        public LivestockStatistic Clone() => this.MemberwiseClone() as LivestockStatistic;

        public virtual LivestockFarm? Farm { get; set; }
    }
}
