using System;
using System.Collections.Generic;

namespace MedicineStockAPI.Models
{
    public partial class Medicinestock
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ChemicalComposition { get; set; }
        public string? TargetAilment { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public int? NumberOfTabletsInStock { get; set; }
    }
}
