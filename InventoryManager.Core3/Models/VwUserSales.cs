using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class VwUserSales
    {
        public string Username { get; set; }
        public string Sku { get; set; }
        public decimal UnitPrice { get; set; }
        public int? TotalQuantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
