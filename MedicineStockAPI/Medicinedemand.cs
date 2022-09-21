using System;
using System.Collections.Generic;

namespace MedicineStockAPI
{
    public partial class Medicinedemand
    {
        public int Id { get; set; }
        public string? Medicine { get; set; }
        public int? DemandCount { get; set; }
    }
}
