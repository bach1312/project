using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class OutbreakDiagnosis
    {
        public int DiagnosisId { get; set; }
        public string? DiagnosisResult { get; set; }
        public DateTime DiagnosisDate { get; set; } = DateTime.Now;
        public string? DoctorName { get; set; }
        public int? OutbreakId { get; set; }

        public virtual Outbreak? Outbreak { get; set; }
        public OutbreakDiagnosis Clone()
        {
            return (OutbreakDiagnosis)this.MemberwiseClone();
        }
    }
}
