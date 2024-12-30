using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class Symptom
    {
        public Symptom()
        {
            Outbreaks = new HashSet<Outbreak>();
        }

        public int SymptomId { get; set; }
        public string SymptomName { get; set; } = null!;
        public string? Description { get; set; }


        public Symptom Clone()
        {
            return (Symptom)this.MemberwiseClone();
        }

        public virtual ICollection<Outbreak> Outbreaks { get; set; }
    }
}
