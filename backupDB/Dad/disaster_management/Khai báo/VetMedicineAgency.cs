using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    //Vet Medicine Agency
    public partial class VetMedicineAgency
    {
        public int AgencyId { get; set; }
        public string AgencyName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }

        internal VetMedicineAgency Clone()
        {
            return (VetMedicineAgency)this.MemberwiseClone(); 
        }
    }
}
