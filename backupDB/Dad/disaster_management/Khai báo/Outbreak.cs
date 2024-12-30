using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class Outbreak
    {
        public Outbreak()
        {
            OutbreakDiagnoses = new HashSet<OutbreakDiagnosis>();
            Vaccinations = new HashSet<Vaccination>();
            Symptoms = new HashSet<Symptom>();
        }

        public int OutbreakId { get; set; }
        public string OutbreakName { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DetectedDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = null!;
        public int? DiseaseId { get; set; }
        public Outbreak Clone()
        {
            return (Outbreak)this.MemberwiseClone();
        }

        public virtual DiseaseType? Disease { get; set; }
        public virtual ICollection<OutbreakDiagnosis> OutbreakDiagnoses { get; set; }
        public virtual ICollection<Vaccination> Vaccinations { get; set; }

        public virtual ICollection<Symptom> Symptoms { get; set; }
    }
}
