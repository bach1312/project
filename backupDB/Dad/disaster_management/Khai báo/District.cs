using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class District
    {
        public District()
        {
            Wards = new HashSet<Ward>();
        }

        public int DistrictId { get; set; }
        public string DistrictName { get; set; } = null!;
        public int? ProvinceId { get; set; }

        public virtual Province? Province { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }

        public District Clone()
        {
            return (District)this.MemberwiseClone();
        }
    }
}
