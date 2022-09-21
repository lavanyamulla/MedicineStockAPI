using System;
using System.Collections.Generic;

namespace MedicineStockAPI
{
    public partial class Pharmacymedicinesupply
    {
        public int Id { get; set; }
        public string? PharmacyName { get; set; }
        public string? MedicineName { get; set; }
        public int? SupplyCount { get; set; }
    }
}
