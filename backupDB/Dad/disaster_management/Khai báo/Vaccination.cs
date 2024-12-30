using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class Vaccination
    {
        public int VaccinationId { get; set; }
        public DateTime VaccinationDate { get; set; } = DateTime.Now;
        public string? VaccineName { get; set; }
        public int? OutbreakId { get; set; }

        public virtual Outbreak? Outbreak { get; set; }

        public Vaccination Clone()
        {
            return (Vaccination)this.MemberwiseClone();
        }
    }
}
