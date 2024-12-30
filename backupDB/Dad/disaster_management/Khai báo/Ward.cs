using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class Ward
    {
        public int WardId { get; set; }
        public string WardName { get; set; } = null!;
        public int? DistrictId { get; set; }

        public virtual District? District { get; set; }

        public Ward Clone()
        {
            return (Ward)MemberwiseClone(); 
        }
    }
}
