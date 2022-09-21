using System;
using System.Collections.Generic;

namespace MedicineStockAPI.Models
{
    public partial class VuDemandsupply
    {
        public int Id { get; set; }
        public string? Medicine { get; set; }
        public int? DemandCount { get; set; }
        public int? SupplyCount { get; set; }
    }
}
