using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class LivestockFarmCondition
    {
        public int ConditionId { get; set; }
        public int? FarmId { get; set; }
        public string? ConditionDetail { get; set; }

        public virtual LivestockFarm? Farm { get; set; }

        public LivestockFarmCondition Clone()
        {
            return this.MemberwiseClone() as LivestockFarmCondition;
        }
    }
}
